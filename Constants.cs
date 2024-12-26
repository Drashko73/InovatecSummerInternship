
namespace Rent_A_Car {
    internal sealed class Constants {

        /// <summary>
        /// Relativna putanja do foldera "Data" u kojem se nalaze fajlovi sa podacima
        /// </summary>
        public const string BASE_FILE_PATH = "../../Data/";
        /// <summary>
        /// Relativna putanja do foldera "Output" u kojem se nalazi fajl sa rezultatima
        /// </summary>
        public const string OUTPUT_FILE_BASE_PATH = "../../Output/";
        /// <summary>
        /// Naziv fajla sa novim rezervacijama
        /// </summary>
        public const string NAZIV_OUTPUT_FAJLA = "nove_rezervacije.csv";

        public const string LINE = "==========================================================================";

        /// <summary>
        /// 10% popusta za BASIC karticu
        /// </summary>
        public const double BASIC_CLANSKA_KARTICA_POPUST = 10;
        /// <summary>
        /// 20% popusta za VIP karticu
        /// </summary>
        public const double VIP_CLANSKA_KARTICA_POPUST = 20;

        /// <summary>
        /// Pocetna cena po danu za iznajmljivanje automobila
        /// </summary>
        public const double POCETNA_CENA_PO_DANU_AUTOMOBIL = 200;
        /// <summary>
        /// Pocecna cena po danu za iznajmljivanje motora
        /// </summary>
        public const double POCETNA_CENA_PO_DANU_MOTOR = 100;


        /* ================================================================================ 
         * Mercedes parametri za racunanje cene po danu 
         * ================================================================================ */
        /// <summary>
        /// kilometraza za poskupljenje Mercedesa
        /// </summary>
        public const double MERCEDES_KILOMETRAZA_MANJE_OD = 50000;
        /// <summary>
        /// uvecanje cene po danu za Mercedes sa manjom kilometrazom
        /// </summary>
        public const double UVECANJE_CENE_MANJA_KILOMETRAZA_MERCEDES = 6;
        /// <summary>
        /// uvecanje cene po danu za Mercedes limuzinu
        /// </summary>
        public const double UVECANJE_CENE_LIMUZINA_MERCEDES = 7;
        /// <summary>
        /// kilometraza za popust na Mercedes
        /// </summary>
        public const double MERCEDES_KILOMETRAZA_VECE_OD = 100000;
        /// <summary>
        /// umanjenje cene po danu za Mercedes hecbek sa vecom kilometrazom
        /// </summary>
        public const double UMANJENJE_CENE_MERCEDES_HECBEK_KILOMETRAZA = 3;

        /* ================================================================================
         * BMW parametri za racunanje cene po danu
         * ================================================================================ */
        /// <summary>
        /// potrosnja za uvecanje cene po danu za BMW
        /// </summary>
        public const double BMW_POTROSNJA_MANJA_OD = 7;
        /// <summary>
        /// uvecanje cene po danu za BMW sa manjom potrosnjom
        /// </summary>
        public const double UVECANJE_CENE_POTROSNJA_BMW = 15;
        /// <summary>
        /// umanjenje cene po danu za BMW sa vecom potrosnjom
        /// </summary>
        public const double UMANJENJE_CENE_POTROSNJA_BMW = 10;
        /// <summary>
        /// umanjenje cene po danu za BMW sa default potrosnjom
        /// </summary>
        public const double UMANJENJE_CENE_POTROSNJA_DEFAULT_BMW = 15;

        /* ================================================================================
         * Peugeot parametri za racunanje cene po danu
         * ================================================================================ */
        /// <summary>
        /// uvecanje cene po danu za Peugeot limuzinu
        /// </summary>
        public const double PEUGEOT_LIMUZINA_UVECANJE_CENE = 15;
        /// <summary>
        /// uvecanje cene po danu za Peugeot karavan
        /// </summary>
        public const double PEUGEOT_KARAVAN_UVECANJE_CENE = 20;
        /// <summary>
        /// umanjenje cene po danu za Peugeot sa default karoserijom
        /// </summary>
        public const double PEUGEOT_DEFAULT_SMANJENJE_CENE = 5;

        /* ================================================================================
         * Yamaha parametri za racunanje cene po danu
         * ================================================================================ */
        /// <summary>
        /// uvecanje cene po danu za Yamaha start
        /// </summary>
        public const double YAMAHA_UVECANJE_CENE_START = 10;
        /// <summary>
        /// snaga za racunanje cene po danu za Yamaha
        /// </summary>
        public const double YAMAHA_SNAGA = 180;
        /// <summary>
        /// uvecanje cene po danu za Yamaha sa vecom snagom
        /// </summary>
        public const double YAMAHA_UVECANJE_CENE_SNAGA = 5;
        /// <summary>
        /// umanjenje cene po danu za Yamaha sa manjom snagom
        /// </summary>
        public const double YAMAHA_UMANJENJE_CENE_SNAGA = 10;
        /// <summary>
        /// uvecanje cene po danu za Yamaha heritage
        /// </summary>
        public const double YAMAHA_HERITAGE_UVECANJE_CENE = 50;
        /// <summary>
        /// uvecanje cene po danu za Yamaha tour
        /// </summary>
        public const double YAMAHA_SPORT_UVECANJE_CENE = 100;
        /// <summary>
        /// umanjenje cene po danu za Yamaha sa default tipom
        /// </summary>
        public const double YAMAHA_TIP_DEFAULT_UMANJENJE_CENE = 10;

        /* ================================================================================
         * Harley parametri za racunanje cene po danu
         * ================================================================================ */
        /// <summary>
        /// uvecanje cene po danu za Harley start
        /// </summary>
        public const double HARLEY_UVECANJE_CENE_START = 15;
        /// <summary>
        /// kubikaza za racunanje cene po danu za Harley
        /// </summary>
        public const double HARLEY_KUBIKAZA = 1200;
        /// <summary>
        /// uvecanje cene po danu za Harley sa vecom kubikazom
        /// </summary>
        public const double HARLEY_UVECANJE_CENE_KUBIKAZA = 10;
        /// <summary>
        /// umanjenje cene po
        /// </summary>
        public const double HARLEY_UMANJENJE_CENE_KUBIKAZA = 5;
    }
}
