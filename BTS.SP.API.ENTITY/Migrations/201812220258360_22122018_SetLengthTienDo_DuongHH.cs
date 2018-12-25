namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22122018_SetLengthTienDo_DuongHH : DbMigration
    {
        public override void Up()
        {
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "DOI_TUONG_TT", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "KE_HOACH_TT", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "LOAI_TT", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "NHOM_TT", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "PHONG_TT", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "TRUONGDOAN_TT", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "SO_NGAY_THANG_QG", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "THOIHAN_TT", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "GIAMSAT_DOAN", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG", c => c.String(maxLength: 500));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG_CHA", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG_CHA", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "MA_DOITUONG", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "GIAMSAT_DOAN", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "THOIHAN_TT", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "SO_NGAY_THANG_QG", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "TRUONGDOAN_TT", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "PHONG_TT", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "NHOM_TT", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "LOAI_TT", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "KE_HOACH_TT", c => c.String(maxLength: 50));
            AlterColumn("BTSTC.PHF_TIENDO_THUCHIEN_KH_CT", "DOI_TUONG_TT", c => c.String(maxLength: 50));
        }
    }
}
