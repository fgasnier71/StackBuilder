using System.Collections.Generic;
using System.Linq;

using log4net;

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;

namespace treeDiM.EdgeCrushTest
{
    public abstract class CardboardQualityAccessor
    {
        protected Dictionary<string, QualityData> _cardboardQualityDictionary;

        public abstract Dictionary<string, QualityData> CardboardQualityDictionary { get; }
        public abstract void AddQuality(string name, string profile, double thickness, double ECT, double rigidityX, double rigidityY);
        public abstract void RemoveQuality(int index);

        public static CardboardQualityAccessor Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new CardboardQualityAccessorWCF();
                return _instance;
            }
        }
        private static CardboardQualityAccessor _instance;
    }

    public class CardboardQualityAccessorWCF : CardboardQualityAccessor
    {
        /// <summary>
        /// Access dictionnary of cardboard qualities
        /// </summary>
        public override Dictionary<string, QualityData> CardboardQualityDictionary
        {
            get
            {
                if (null == _cardboardQualityDictionary)
                {
                    // instantiate
                    _cardboardQualityDictionary = new Dictionary<string, QualityData>();

                    try
                    {
                        using (var wcfClient = new WCFClient())
                        {
                            var qualities = wcfClient.Client.GetAllCardboardQualities();
                            foreach (var q in qualities)
                            {
                                try
                                {
                                    _cardboardQualityDictionary.Add(
                                        q.Name,
                                        new QualityData(q.ID, q.Name, q.Profile, q.Thickness, q.ECT, q.Rigidity[0], q.Rigidity[1])
                                        );
                                }
                                catch (Exception ex)
                                {
                                    _log.Error($"{q.Name} -> {ex.Message}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex.ToString());
                    }
                }
                return _cardboardQualityDictionary;
            }
        }
        /// <summary>
        /// Add new cardboard quality
        /// </summary>
        public override void AddQuality(string name, string profile, double thickness, double ECT, double rigidityX, double rigidityY)
        {
            try
            {
                using (WCFClient wcfClient = new WCFClient())
                {
                    wcfClient.Client.CreateNewCardboardQuality(name, profile, thickness, ECT, rigidityX, rigidityY);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            _cardboardQualityDictionary = null;
        }
        /// <summary>
        /// Remove cardboard quality
        /// </summary>
        public override void RemoveQuality(int index)
        {
            try
            {
                var dict = CardboardQualityDictionary;
                if (index < dict.Count)
                {
                    var qualityData = dict.Values.ElementAt(index);
                    using (WCFClient wcfClient = new WCFClient())
                    {
                        wcfClient.Client.RemoveCardboardQuality(
                            new DCCardboardQuality()
                            {
                                ID =  qualityData.ID,
                                Name = qualityData.Name,
                                Profile = qualityData.Profile,
                                Thickness = qualityData.Thickness,
                                ECT = qualityData.ECT,
                                Rigidity = new double[2]{ qualityData.RigidityDX, qualityData.RigidityDY},
                                YoungModulus = 0.0,
                                SurfacicMass = 0.0
                            }
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            _cardboardQualityDictionary = null;
        }

        private static ILog _log = LogManager.GetLogger(typeof(CardboardQualityAccessorWCF));
    }
}
