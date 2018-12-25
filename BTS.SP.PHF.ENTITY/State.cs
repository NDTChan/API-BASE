namespace BTS.SP.PHF.ENTITY
{
    public class State
    {
        public enum StateStatus
        {
            IsNotActive = 0,
            IsActive = 10,
        }

        public enum LoaiMa
        {
            PHONGBAN,
            TTB
        }

        public enum LoaiThanhTra
        {
            TTR_B, // thanh tra bộ

            TTR_K_B //Thanh tra đơn vị thuộc bộ
        }
    }
}
