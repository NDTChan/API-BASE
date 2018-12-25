namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08122018_AlterTableDVSN_DuongHH : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_BM_02TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
            AddColumn("BTSTC.PHF_BM_03TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
            AddColumn("BTSTC.PHF_BM_04TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
            AddColumn("BTSTC.PHF_BM_06TT_DVSN", "TITLE_NGUYENNHAN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHF_BM_06TT_DVSN", "TITLE_NGUYENNHAN");
            DropColumn("BTSTC.PHF_BM_04TT_DVSN", "TITLE_NGUYENNHAN");
            DropColumn("BTSTC.PHF_BM_03TT_DVSN", "TITLE_NGUYENNHAN");
            DropColumn("BTSTC.PHF_BM_02TT_DVSN", "TITLE_NGUYENNHAN");
        }
    }
}
