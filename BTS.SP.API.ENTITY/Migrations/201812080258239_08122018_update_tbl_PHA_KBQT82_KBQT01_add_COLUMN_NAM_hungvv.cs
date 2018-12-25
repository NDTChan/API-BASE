namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08122018_update_tbl_PHA_KBQT82_KBQT01_add_COLUMN_NAM_hungvv : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHA_KBQT01", "NAM", c => c.Decimal(precision: 10, scale: 0));
            AddColumn("BTSTC.PHA_KBQT82", "NAM", c => c.Decimal(precision: 10, scale: 0));
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHA_KBQT82", "NAM");
            DropColumn("BTSTC.PHA_KBQT01", "NAM");
        }
    }
}
