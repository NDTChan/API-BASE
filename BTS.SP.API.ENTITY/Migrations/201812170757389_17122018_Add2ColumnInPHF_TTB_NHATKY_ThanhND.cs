namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17122018_Add2ColumnInPHF_TTB_NHATKY_ThanhND : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_TTB_NHATKY", "TU_NGAY", c => c.DateTime());
            AddColumn("BTSTC.PHF_TTB_NHATKY", "DEN_NGAY", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHF_TTB_NHATKY", "DEN_NGAY");
            DropColumn("BTSTC.PHF_TTB_NHATKY", "TU_NGAY");
        }
    }
}
