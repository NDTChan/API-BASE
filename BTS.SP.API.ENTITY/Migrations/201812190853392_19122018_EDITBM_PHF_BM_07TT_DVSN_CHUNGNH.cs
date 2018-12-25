namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19122018_EDITBM_PHF_BM_07TT_DVSN_CHUNGNH : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_BM_07TT_DVSN", "IS_BOLD", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("BTSTC.PHF_BM_07TT_DVSN", "IS_ITALIC", c => c.Decimal(precision: 10, scale: 0));
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHF_BM_07TT_DVSN", "IS_ITALIC");
            DropColumn("BTSTC.PHF_BM_07TT_DVSN", "IS_BOLD");
        }
    }
}
