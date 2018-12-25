namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24122018_UpdateColumnPHF_TTB_NHATKY_ThanhND : DbMigration
    {
        public override void Up()
        {
            AlterColumn("BTSTC.PHF_TTB_NHATKY", "NOIDUNG_BAOCAO", c => c.String(maxLength: 1000));
            AlterColumn("BTSTC.PHF_TTB_NHATKY", "CONGVIEC_THUCHIEN", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("BTSTC.PHF_TTB_NHATKY", "CONGVIEC_THUCHIEN", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TTB_NHATKY", "NOIDUNG_BAOCAO", c => c.String(maxLength: 50));
        }
    }
}
