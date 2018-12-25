namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18122018_AddColumnPHF_TTB_NHATKY_ThanhND : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_TTB_NHATKY", "CONGVIEC_THUCHIEN", c => c.String(maxLength: 50));
            AddColumn("BTSTC.PHF_TTB_NHATKY", "QD_SO", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHF_TTB_NHATKY", "QD_SO");
            DropColumn("BTSTC.PHF_TTB_NHATKY", "CONGVIEC_THUCHIEN");
        }
    }
}
