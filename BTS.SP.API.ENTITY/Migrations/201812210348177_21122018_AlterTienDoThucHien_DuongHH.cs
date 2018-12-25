namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21122018_AlterTienDoThucHien_DuongHH : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG", c => c.String(maxLength: 50));
            AddColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG_CHA", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG_CHA");
            DropColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG");
        }
    }
}
