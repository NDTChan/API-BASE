namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _07122018_EDITBM_PHF_04TT_CQHC_CHUNGNH : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "SOTIEN", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "THUKHONG_QDNC_NN", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "THUCAOTHAP_QDNC_NN", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "THUKHONG_SSQT_NN", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "CHUAGHI_THUCHI_NN", c => c.String(maxLength: 1000));
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "CONGVIEC");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "TRANGTHAI_TRIENKHAI");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "VANBAN_SAIPHAM");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "HAUQUA");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "NGUYENNHAN");
        }
        
        public override void Down()
        {
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "NGUYENNHAN", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "HAUQUA", c => c.String(maxLength: 1000));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "VANBAN_SAIPHAM", c => c.String(maxLength: 500));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "TRANGTHAI_TRIENKHAI", c => c.String(maxLength: 200));
            AddColumn("BTSTC.PHF_BM_04TT_CQHC", "CONGVIEC", c => c.String(maxLength: 1000));
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "CHUAGHI_THUCHI_NN");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "THUKHONG_SSQT_NN");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "THUCAOTHAP_QDNC_NN");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "THUKHONG_QDNC_NN");
            DropColumn("BTSTC.PHF_BM_04TT_CQHC", "SOTIEN");
        }
    }
}
