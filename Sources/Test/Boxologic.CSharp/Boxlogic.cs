using System;
using System.Collections.Generic;

namespace Boxologic.CSharp
{
    public class Boxlogic
    {
        Scrappad scrapfirst, trash;
        List<BoxInfo> listBox = new List<BoxInfo>();
        DateTime _timeStart, _timeStop;
        bool packing = true;

        double layerThickness = 0.0;
        double remainpy = 0.0, remainpz = 0.0;
        bool layerdone = false, evened = false;

        private double _pallet_volume_used_percentage = 0.0;
        private double _packedvolume = 0, _best_solution_volume = 0;
        private int _number_packed_boxes = 0, _packednumbox = 0;
        private Dictionary<int, double> _best_iterations = new Dictionary<int, double>();

        public void Run(BoxItem[] listBoxItem, int palletLength, int palletWidth, int palletHeight)
        {
            packing = true;

            // boxes
            foreach (BoxItem bi in listBoxItem)
            {
                for (int i=0; i<bi.N; ++i)
                    listBox.Add(new BoxInfo() { Dim1 = bi.Boxx, Dim2 = bi.Boxy, Dim3 = bi.Boxz, N = bi.N });
            }
            // pallet
            _timeStart = DateTime.Now;
            Execute_iterations( new Pallet(palletLength, palletWidth, palletHeight) );
            _timeStop = DateTime.Now;
            Report_results();
        }

        public void Execute_iterations(Pallet p)
        {
            int numberOfIterations = 0;
            int best_iteration = 0;
            int best_variant = 0;

            for (int variant = 0; variant < 6; ++variant)
            {
                p.Orientation = variant;

                List<Layer> layers = new List<Layer>();
                List_candidate_layers(p, listBox, ref layers);

                int iLayerIndex = 0, itelayer = 0;
                foreach (Layer l in layers)
                {
                    ++numberOfIterations;
                    double elapsed_time = (DateTime.Now - _timeStart).TotalSeconds;
                    Console.WriteLine(
                        string.Format("VARIANT: {0}; ITERATION (TOTAL): {1}; BEST SO FAR: {2}; TIME: {3}"
                            , variant, numberOfIterations, _pallet_volume_used_percentage, elapsed_time));

                    double layerThickness = l.LayerDim;
                    itelayer = iLayerIndex;

                    remainpy = p.LayoutWidth;
                    remainpz = p.LayoutHeight;

                    // reset boxes
                    foreach (BoxInfo bi in listBox)
                        bi.Is_packed = false;

                    double layerinlayer = 0.0;
                    layerdone = false;

                    double packedy = 0.0;

                    // ###
                    do
                    {
                        layerinlayer = 0;
                        layerdone = false;

                        Pack_layer(p);

                        packedy = packedy + layerThickness;
                        remainpy = p.LayoutWidth - packedy;

                        if (layerinlayer > 0)
                        {
                            layerThickness = layerinlayer;
                            layerdone = false;

                            Pack_layer(p);
                        }
                        Find_layer(remainpy, p, ref layerThickness);
                    }
                    while (packing);
                    // END DO-WHILE

                    if (_packedvolume >= _best_solution_volume)
                    {
                        _best_solution_volume = _packedvolume;
                        best_variant = variant;
                        best_iteration = itelayer;
                        _number_packed_boxes = _packednumbox;

                        _best_iterations[itelayer] = _packedvolume;
                    }


                    best_iteration = itelayer;

                    ++iLayerIndex;
                }
            }
        }

        private bool Pack_layer(Pallet p)
        {
            if (0.0 == layerThickness)
            {
                packing = false;
                return true;
            }

            scrapfirst = new Scrappad() { cumx = p.LayoutLength, cumz = 0.0 };

            while (true)
            {
                Scrappad smallestz = FindSmallestZ();


                if (null == smallestz.prev && null == smallestz.next)
                {
                    //*** SITUATION-1: NO BOXES ON THE RIGHT AND LEFT SIDES ***
                    int cboxi = 0;
                    double lenx = smallestz.cumx;
                    double lpz = remainpz - smallestz.cumz;
                    double bfx = 0.0, bfy = 0.0, bfz = 0.0, bbfx = 0.0, bbfy = 0.0, bbfz = 0.0;
                    int boxi = 0, bboxi = 0;
                    Find_box(lenx, layerThickness, remainpy, lpz, lpz,
                        ref bfx, ref bfy, ref bfz,
                        ref bbfx, ref bbfy, ref bbfz,
                        ref boxi, ref bboxi);


                    if (layerdone) break;
                    if (evened) continue;



                    BoxInfo bi = listBox[cboxi];
                    VolumeCheck(ref bi);
                }
                else if (null == smallestz.prev)
                {
                    //*** SITUATION-2: NO BOXES ON THE LEFT SIDE ***
                    int cboxi = 0;
                    BoxInfo bi = listBox[cboxi];
                    VolumeCheck(ref bi);
                }
                else if (null == smallestz.next)
                {
                    //*** SITUATION-3: NO BOXES ON THE RIGHT SIDE ***
                    int cboxi = 0;
                    BoxInfo bi = listBox[cboxi];
                    VolumeCheck(ref bi);
                }
                else if (smallestz.prev.cumz == smallestz.next.cumz)
                {
                    //*** SITUATION-4: THERE ARE BOXES ON BOTH OF THE SIDES ***
                    //*** SUBSITUATION-4A: SIDES ARE EQUAL TO EACH OTHER ***
                    int cboxi = 0;
                    BoxInfo bi = listBox[cboxi];
                    VolumeCheck(ref bi);
                }
                else
                {
                    //*** SUBSITUATION-4B: SIDES ARE NOT EQUAL TO EACH OTHER ***
                    int cboxi = 0;
                    BoxInfo bi = listBox[cboxi];
                    VolumeCheck(ref bi);
                }

            }
            return true;
        }
        private int Find_layer(double thickness, Pallet p, ref double layerthickness)
        {
            double eval = Double.MaxValue;
            layerThickness = 0.0;
            for (int x = 0; x < listBox.Count; ++x)
            {
                BoxInfo bi = listBox[x];
                if (bi.Is_packed)
                    continue;

                double exdim = 0.0, dimen2 = 0.0, dimen3 = 0.0;
                for (int y = 1; y <= 3; y++)
                {
                    switch (y)
                    {
                        case 1:
                            exdim = bi.Dim1;
                            dimen2 = bi.Dim2;
                            dimen3 = bi.Dim3;
                            break;
                        case 2:
                            exdim = bi.Dim2;
                            dimen2 = bi.Dim1;
                            dimen3 = bi.Dim3;
                            break;
                        case 3:
                            exdim = bi.Dim3;
                            dimen2 = bi.Dim1;
                            dimen3 = bi.Dim2;
                            break;
                        default:
                            break;
                    }
                    double layereval = 0;
                    if ((exdim <= thickness)
                        && (((dimen2 <= p.LayoutLength) && (dimen3 <= p.LayoutHeight))
                        || ((dimen3 <= p.LayoutLength) && (dimen2 <= p.LayoutHeight))))
                    {
                        for (int z = 0; z < listBox.Count; z++)
                        {
                            if (!(x == z) && !(listBox[z].Is_packed))
                            {
                                double dimdif = Math.Abs(exdim - listBox[z].Dim1);
                                if (Math.Abs(exdim - listBox[z].Dim2) < dimdif)
                                    dimdif = Math.Abs(exdim - listBox[z].Dim2);
                                if (Math.Abs(exdim - listBox[z].Dim3) < dimdif)
                                    dimdif = Math.Abs(exdim - listBox[z].Dim3);
                                layereval = layereval + dimdif;
                            }
                        }
                        if (layereval < eval)
                        {
                            eval = layereval;
                            layerthickness = exdim;
                        }
                    }
                }
            }
            if (layerThickness == 0 || layerThickness > remainpy)
                packing = false;
            return 0;
        }

        private Scrappad FindSmallestZ()
        {
            Scrappad scrapmemb = scrapfirst, smallestz = scrapfirst;
            while (null != scrapmemb.next)
            {
                if (scrapmemb.next.cumz < smallestz.cumz)
                    smallestz = scrapmemb.next;
                scrapmemb = scrapmemb.next;
            }
            return smallestz;
        }

        /// <summary>
        /// AFTER FINDING EACH BOX, THE CANDIDATE BOXES AND THE CONDITION OF THE LAYER
        /// ARE EXAMINED
        /// </summary>
        private void CheckFound(int boxi, int bboxi,
            double boxx, double boxy, double boxz,
            double bboxx, double bboxy, double bboxz,
            ref Scrappad smallestz, ref double prelayer, ref double lilz,
            double layerthickness,
            ref int cboxi, ref double cboxx, ref double cboxy, ref double cboxz,
            ref double layerinlayer, ref bool layerDone)
        {
            evened = false;
            if (boxi >= 0)
            {
                cboxi = boxi;
                cboxx = boxx;
                cboxy = boxy;
                cboxz = boxz;
            }
            else
            {
                if ((bboxi >= 0) && (layerinlayer > 0 || (null == smallestz.prev && null == smallestz.next)))
                {
                    if (layerinlayer == 0.0)
                    {
                        prelayer = layerthickness;
                        lilz = smallestz.cumz;
                    }
                    cboxi = bboxi;
                    cboxx = bboxx;
                    cboxy = bboxy;
                    cboxz = bboxz;
                    layerinlayer = layerinlayer + bboxy - layerthickness;
                    layerthickness = bboxy;
                }
                else
                {
                    if (null == smallestz.prev && null == smallestz.next)
                    {
                        layerdone = true;
                    }
                    else
                    {
                        evened = true;
                        if (null == smallestz.prev)
                        {
                            trash = smallestz.next;
                            smallestz.cumx = smallestz.next.cumx;
                            smallestz.cumz = smallestz.next.cumz;
                            smallestz.next = smallestz.next.next;
                            if (null != smallestz.next)
                            {
                                smallestz.next.prev = smallestz;
                            }
                            trash = null;
                        }
                        else if (null == smallestz.next)
                        {
                            smallestz.prev.next = null;
                            smallestz.prev.cumx = smallestz.cumx;
                            smallestz = null;
                        }
                        else
                        {
                            if (smallestz.prev.cumz == smallestz.next.cumz)
                            {
                                smallestz.prev.next = smallestz.next.next;
                                if (null != smallestz.next.next)
                                {
                                    smallestz.next.next.prev = smallestz.prev;
                                }
                                smallestz.prev.cumx = smallestz.next.cumx;
                                smallestz.next = null;
                                smallestz = null;
                            }
                            else
                            {
                                smallestz.prev.next = smallestz.next;
                                smallestz.next.prev = smallestz.prev;
                                if (smallestz.prev.cumz < smallestz.next.cumz)
                                {
                                    smallestz.prev.cumx = smallestz.cumx;
                                }
                                smallestz = null;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// AFTER PACKING OF EACH BOX, 100% PACKING CONDITION IS CHECKED
        /// </summary>
        private void VolumeCheck(ref BoxInfo bi)
        {
            bi.Is_packed = true;


            packing = false;
        }

        public void List_candidate_layers(Pallet p, List<BoxInfo> listBoxes, ref List<Layer> listLayers)
        {
            foreach (BoxInfo bi in listBoxes)
            {
                for (int y = 0; y < 3; ++y)
                {
                    double exdim = 0.0, dimen2= 0.0, dimen3 = 0.0;
                    switch (y)
                    {
                        case 1:
                            exdim = bi.Dim1;
                            dimen2 = bi.Dim2;
                            dimen3 = bi.Dim3;
                            break;
                        case 2:
                            exdim = bi.Dim2;
                            dimen2 = bi.Dim1;
                            dimen3 = bi.Dim3;
                            break;
                        case 3:
                            exdim = bi.Dim3;
                            dimen2 = bi.Dim1;
                            dimen3 = bi.Dim2;
                            break;
                    }

                    if (
                        (exdim > p.LayoutWidth)
                        ||
                        (
                            ((dimen2 > p.LayoutLength) || (dimen3 > p.LayoutHeight))
                            && ((dimen3 > p.LayoutLength) || (dimen2 > p.LayoutHeight))
                        )
                    )
                        continue;

                    if (null != listLayers.Find(lay => Math.Abs(lay.LayerDim - exdim) < 0.001))
                        continue;

                    double layereval = 0.0;
                    foreach (BoxInfo bi2 in listBoxes)
                    {
                        double dimdif = Math.Abs(exdim - bi2.Dim1);
                        if (Math.Abs(exdim - bi2.Dim2) < dimdif)
                            dimdif = Math.Abs(exdim - bi2.Dim2);
                        if (Math.Abs(exdim - bi2.Dim3) < dimdif)
                            dimdif = Math.Abs(exdim - bi2.Dim3);
                        layereval = layereval + dimdif;
                    }
                    listLayers.Add(new Layer() { LayerEval = layereval, LayerDim = exdim });
                }
            }
            listLayers.Sort(new LayerComparer());
        }

        /// <summary>
        /// FINDS THE MOST PROPER BOXES BY LOOKING AT ALL SIX POSSIBLE ORIENTATIONS,
        /// EMPTY SPACE GIVEN, ADJACENT BOXES, AND PALLET LIMITS 
        /// </summary>
        private void Find_box(double hmx, double hy, double hmy, double hz, double hmz, 
            ref double bfx, ref double bfy, ref double bfz,
            ref double bbfx, ref double bbfy, ref double bbfz,
            ref int boxi, ref int bboxi)
        {
            bfx = Double.MaxValue; bfy = Double.MaxValue; bfz = Double.MaxValue;
            bbfx = Double.MaxValue; bbfy = Double.MaxValue; bbfz = Double.MaxValue;
            double boxx = 0.0, boxy = 0.0, boxz = 0.0,
                bboxx = 0.0, bboxy = 0.0, bboxz = 0.0;

            for (int y = 1; y < listBox.Count; y += listBox[y].N)
            {
                int x = y;
                for (x = y; x < x + listBox[y].N - 1; x++)
                {
                    if (!listBox[x].Is_packed) break;
                }

                if (listBox[x].Is_packed) continue;
                if (x > listBox.Count) return;
                BoxInfo bi = listBox[x];
                Analyse_box(x, hmx, hy, hmy, hz, hmz, bi.Dim1, bi.Dim2, bi.Dim3,
                    ref boxx, ref boxy, ref boxz, ref bfx, ref bfy, ref bfz,
                    ref bboxx, ref bboxy, ref bboxz, ref bbfx, ref bbfy, ref bbfz,
                    ref boxi, ref bboxi);
                if ((bi.Dim1 == bi.Dim3) && (bi.Dim3 == bi.Dim2))
                    continue;
                Analyse_box(x, hmx, hy, hmy, hz, hmz, bi.Dim1, bi.Dim3, bi.Dim2,
                    ref boxx, ref boxy, ref boxz, ref bfx, ref bfy, ref bfz,
                    ref bboxx, ref bboxy, ref bboxz, ref bbfx, ref bbfy, ref bbfz,
                    ref boxi, ref bboxi);
                Analyse_box(x, hmx, hy, hmy, hz, hmz, bi.Dim2, bi.Dim1, bi.Dim3,
                    ref boxx, ref boxy, ref boxz, ref bfx, ref bfy, ref bfz,
                    ref bboxx, ref bboxy, ref bboxz, ref bbfx, ref bbfy, ref bbfz,
                    ref boxi, ref bboxi);
                Analyse_box(x, hmx, hy, hmy, hz, hmz, bi.Dim2, bi.Dim3, bi.Dim1,
                    ref boxx, ref boxy, ref boxz, ref bfx, ref bfy, ref bfz,
                    ref bboxx, ref bboxy, ref bboxz, ref bbfx, ref bbfy, ref bbfz,
                    ref boxi, ref bboxi);
                Analyse_box(x, hmx, hy, hmy, hz, hmz, bi.Dim3, bi.Dim1, bi.Dim2,
                    ref boxx, ref boxy, ref boxz, ref bfx, ref bfy, ref bfz,
                    ref bboxx, ref bboxy, ref bboxz, ref bbfx, ref bbfy, ref bbfz,
                    ref boxi, ref bboxi);
                Analyse_box(x, hmx, hy, hmy, hz, hmz, bi.Dim3, bi.Dim2, bi.Dim1,
                    ref boxx, ref boxy, ref boxz, ref bfx, ref bfy, ref bfz,
                    ref bboxx, ref bboxy, ref bboxz, ref bbfx, ref bbfy, ref bbfz,
                    ref boxi, ref bboxi);
            }
        }

        /// <summary>
        /// ANALYZES EACH UNPACKED BOX TO FIND THE BEST FITTING ONE TO THE EMPTY SPACE
        /// GIVEN
        /// </summary>
        private void Analyse_box(int x, double hmx, double hy, double hmy, double hz, double hmz,
            double dim1, double dim2, double dim3,
            ref double boxx, ref double boxy, ref double boxz,
            ref double bfx, ref double bfy, ref double bfz,
            ref double bboxx, ref double bboxy, ref double bboxz,
            ref double bbfx, ref double bbfy, ref double bbfz,
            ref int boxi, ref int bboxi)
        {
            if (dim1 <= hmx && dim2 <= hmy && dim3 <= hmz)
            {
                if (dim2 <= hy)
                {
                    if (hy - dim2 < bfy)
                    {
                        boxx = dim1;
                        boxy = dim2;
                        boxz = dim3;
                        bfx = hmx - dim1;
                        bfy = hy - dim2;
                        bfz = Math.Abs(hz - dim3);
                        boxi = x;
                    }
                    else if (hy - dim2 == bfy && hmx - dim1 < bfx)
                    {
                        boxx = dim1;
                        boxy = dim2;
                        boxz = dim3;
                        bfx = hmx - dim1;
                        bfy = hy - dim2;
                        bfz = Math.Abs(hz - dim3);
                        boxi = x;
                    }
                    else if (hy - dim2 == bfy && hmx - dim1 == bfx && Math.Abs(hz - dim3) < bfz)
                    {
                        boxx = dim1;
                        boxy = dim2;
                        boxz = dim3;
                        bfx = hmx - dim1;
                        bfy = hy - dim2;
                        bfz = Math.Abs(hz - dim3);
                        boxi = x;
                    }
                }
                else
                {
                    if (dim2 - hy < bbfy)
                    {
                        bboxx = dim1;
                        bboxy = dim2;
                        bboxz = dim3;
                        bbfx = hmx - dim1;
                        bbfy = dim2 - hy;
                        bbfz = Math.Abs(hz - dim3);
                        bboxi = x;
                    }
                    else if (dim2 - hy == bbfy && hmx - dim1 < bbfx)
                    {
                        bboxx = dim1;
                        bboxy = dim2;
                        bboxz = dim3;
                        bbfx = hmx - dim1;
                        bbfy = dim2 - hy;
                        bbfz = Math.Abs(hz - dim3);
                        bboxi = x;
                    }
                    else if (dim2 - hy == bbfy && hmx - dim1 == bbfx && Math.Abs(hz - dim3) < bbfz)
                    {
                        bboxx = dim1;
                        bboxy = dim2;
                        bboxz = dim3;
                        bbfx = hmx - dim1;
                        bbfy = dim2 - hy;
                        bbfz = Math.Abs(hz - dim3);
                        bboxi = x;
                    }
                }
            }
        }

        public void Report_results()
        {

        }

    }
}
