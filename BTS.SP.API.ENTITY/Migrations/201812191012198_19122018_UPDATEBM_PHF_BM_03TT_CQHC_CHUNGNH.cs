namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19122018_UPDATEBM_PHF_BM_03TT_CQHC_CHUNGNH : DbMigration
    {
        public override void Up()
        {
            DropColumn("BTSTC.PHF_BM_03TT_CQHC", "DUTOANGIAO_KHONGDUNG");
        }
        
        public override void Down()
        {
            AddColumn("BTSTC.PHF_BM_03TT_CQHC", "DUTOANGIAO_KHONGDUNG", c => c.String(maxLength: 500));
        }
    }
}
