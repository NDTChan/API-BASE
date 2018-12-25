namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12122018_updateDVSN_HT : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DVLAP_NAMLK", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_DVLAP", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_NAMKT", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_02TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
            AddColumn("BTSTC.PHF_BM_03TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
            AddColumn("BTSTC.PHF_BM_04TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
            AddColumn("BTSTC.PHF_BM_06TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
            AddColumn("BTSTC.PHF_BM_07TT_CQHC", "IS_BOLD", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AddColumn("BTSTC.PHF_BM_07TT_CQHC", "IS_ITALIC", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AddColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN_TRICH_CAOHON", c => c.String());
            AddColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN_TRICH_SAINGUON", c => c.String());
            AddColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN_TRICH_SAI_TYLE", c => c.String());
            DropColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN");
        }
        
        public override void Down()
        {
            AddColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN", c => c.String());
            DropColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN_TRICH_SAI_TYLE");
            DropColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN_TRICH_SAINGUON");
            DropColumn("BTSTC.PHF_BM_08TT_DVSN", "NGUYENNHAN_TRICH_CAOHON");
            DropColumn("BTSTC.PHF_BM_07TT_CQHC", "IS_ITALIC");
            DropColumn("BTSTC.PHF_BM_07TT_CQHC", "IS_BOLD");
            DropColumn("BTSTC.PHF_BM_06TT_DVSN", "TITLE_NGUYENNHAN");
            DropColumn("BTSTC.PHF_BM_04TT_DVSN", "TITLE_NGUYENNHAN");
            DropColumn("BTSTC.PHF_BM_03TT_DVSN", "TITLE_NGUYENNHAN");
            DropColumn("BTSTC.PHF_BM_02TT_DVSN", "TITLE_NGUYENNHAN");
            DropColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_NAMKT");
            DropColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DUOCGIAO_DVLAP");
            DropColumn("BTSTC.PHF_BM_02TT_CQHC", "DUTOAN_DVLAP_NAMLK");
        }
    }
}
