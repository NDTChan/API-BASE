namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23122018_Add_TieuChiDanhGiaRuiRo_dvc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "BTSTC.PHF_TIEUCHI_DGRR_DETAIL",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REF_ID = c.String(nullable: false, maxLength: 50),
                        MA = c.String(nullable: false, maxLength: 255),
                        TEN = c.String(nullable: false, maxLength: 255),
                        THOIGIANNOP = c.DateTime(),
                        SONGAYNOPCHAM = c.Decimal(precision: 10, scale: 0),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "BTSTC.PHF_TIEUCHI_DGRR",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        REF_ID = c.String(nullable: false, maxLength: 50),
                        LOAINHAP_TIEUCHI_DGRR = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LOAIMANHAP = c.Decimal(nullable: false, precision: 10, scale: 0),
                        MA_LOAITHANHTRA = c.String(nullable: false, maxLength: 50),
                        MA_DOTTHANHTRA = c.String(nullable: false, maxLength: 50),
                        TUNGAY = c.DateTime(nullable: false),
                        DENNGAY = c.DateTime(nullable: false),
                        I_CREATE_DATE = c.DateTime(),
                        I_CREATE_BY = c.String(maxLength: 50),
                        I_UPDATE_DATE = c.DateTime(),
                        I_UPDATE_BY = c.String(maxLength: 50),
                        I_STATE = c.String(maxLength: 50),
                        UNITCODE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("BTSTC.PHF_TIEUCHI_DGRR");
            DropTable("BTSTC.PHF_TIEUCHI_DGRR_DETAIL");
        }
    }
}
