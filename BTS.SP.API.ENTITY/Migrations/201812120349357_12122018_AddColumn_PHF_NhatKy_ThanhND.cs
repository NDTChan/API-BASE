namespace BTS.SP.API.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12122018_AddColumn_PHF_NhatKy_ThanhND : DbMigration
    {
        public override void Up()
        {
            AddColumn("BTSTC.PHF_TTB_NHATKY", "TENTEP", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("BTSTC.PHF_TTB_NHATKY", "TENTEP");
        }
    }
}
