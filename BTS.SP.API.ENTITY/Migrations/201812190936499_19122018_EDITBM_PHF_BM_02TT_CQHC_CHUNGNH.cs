namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19122018_EDITBM_PHF_BM_02TT_CQHC_CHUNGNH : DbMigration
    {
        public override void Up()
        {
            DropColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DVLAP_NAMLK");
            DropColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_DVLAP");
            DropColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_NAMKT");
        }
        
        public override void Down()
        {
            AddColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_NAMKT", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_DVLAP", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DVLAP_NAMLK", c => c.String(maxLength: 1000));
        }
    }
}
