namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15122018_add_column_MA_DBHC_dm_TKKHOBAC_hungvv : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.DM_TKKHOBAC", "MA_DBHC", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.DM_TKKHOBAC", "MA_DBHC");
        }
    }
}
