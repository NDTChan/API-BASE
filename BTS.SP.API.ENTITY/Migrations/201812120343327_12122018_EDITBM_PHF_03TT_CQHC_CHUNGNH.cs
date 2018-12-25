namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12122018_EDITBM_PHF_03TT_CQHC_CHUNGNH : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_BM_03TT_CQHC", "TITLE_NGUYENNHAN", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHF_BM_03TT_CQHC", "TITLE_NGUYENNHAN");
        }
    }
}
