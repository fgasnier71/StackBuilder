#region Using directives
#endregion

namespace Sharp3D.Pisinger
{
    public class Item
    {
        public short no;         /* item number */
        public int w;            /* item width  (x-size) */
        public int h;            /* item height (y-size) */
        public int d;            /* item depth  (z-size) */
        public int x;            /* optimal x-position */
        public int y;            /* optimal y-position */
        public int z;            /* optimal z-position */
        public short bno;        /* bin number */
        public bool k;           /* is the item chosen */
        public int vol;          /* volume of item */
        Item itemRef;            /* reference to original item (if necessary) */
    }

    public class HeurPair
    {
        public int lno;
        public int d;
        public int bno;
        public int z;
        public int b;
    }

    public class Point
    {
        public int x;
        public int y;
        public int z;
    }

    public class AllInfo
    {
        int W;            /* x-size of bin             */
        int H;            /* y-size of bin             */
        int D;            /* z-size of bin             */
        int BVOL;         /* volume of a bin           */
        short n;            /* number of items           */
        Item fitem;       /* first item in problem     */
        Item litem;       /* last item in problem      */
        Item fsol;        /* first item in current solution */
        Item lsol;        /* last item in current solution  */
        Item fopt;        /* first item in optimal solution */
        Item lopt;        /* last item in optimal solution  */
        bool closed;      /* for each bin indicator whether closed */
        Item fclosed;     /* first item in closed bins */
        Item lclosed;     /* last item in closed bins */
        short noc;          /* number of closed bins */
        int mindim;       /* currently smallest box length  */
        int maxdim;       /* currently largest box length   */
        int maxfill;      /* the best filling found         */
        int mcut;         /* how many siblings at each node in b&b */
        bool optimal;      /* a solution which packs all found */

        /* different bounds */
        short bound0;       /* Bound L_0 at root node */
        short bound1;       /* Bound L_1 at root node */
        short bound2;       /* Bound L_2 at root node */
        short lb;           /* best of the above */
        short z;            /* currently best solution */

        /* controle of 3d filler */
        long maxiter;      /* max iterations in onebin_fill */
        long miss;         /* number of items not packed in onebin_fill  */

        /* debugging and controle information */
        long iterates;     /* iterations in branch-and-bound */
        long exfill;       /* number of calls to onebin_fill algorithm */
        long iter3d;       /* iterations in onebin_fill */
        long zlayer;       /* heuristic solution layer */
        long zmcut;        /* heuristic solution mcut */
        double time;         /* computing time */
        double lhtime;       /* layer heuristic computing time */
        double mhtime;       /* mcut heuristic computing time */
        long didpush;      /* did the lower bound push up bound */
        long maxclose;     /* max number of closed bins at any time */
    }
}
