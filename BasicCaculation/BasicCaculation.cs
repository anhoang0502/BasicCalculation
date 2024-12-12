using BasicCaculation.application;
using System;
using System.Windows.Forms;

namespace BasicCaculation
{
    public partial class CaculateForm : Form
    {
        public CaculateForm()
        {
            InitializeComponent();
        }
        // để private vì chỉ mặc định thao tác này chỉ được kích hoạt trong cái namespace này
        private void NhapGiaTri(object sender, EventArgs e)
        {
            string[] lines = thanh_hien_thi.Lines;
            if (thanh_hien_thi.Lines[1] == "0")
            {
                lines[1] = "";
            }
            lines[1] += Helper.nhapgiatri(sender);
            thanh_hien_thi.Lines = lines;
        }
        //lấy tất cả các dòng từ ô thanh_hien_thi
        //Nếu dòng đang hiển thị (dòng thứ 2) là 0 thì xóa nội dung dòng đó (là 0)
        //nhapgiatri là 1 phương thức của class Helper để hỗ trợ lấy text từ button
        //Cập nhật toàn bộ văn bản của thanh_hien_thi
        private void XoaGiaTri(object sender, EventArgs e)
        {
            if (thanh_hien_thi.Lines[1] != "0")
            {
                thanh_hien_thi.Lines = new string[] { "", Helper.xoagiatri(thanh_hien_thi.Lines[1]) };
            }
        }
        //vì Lines => các giá trị trong mảng sẽ được nhập theo chiều dọc
        //EventArgs => những thuộc tính trong thằng sender???????/
        //sender giá trị truyền tới từ button (thao tác khi nhấn, nó là cái nhấn)
        private void XoaTatCa(object sender, EventArgs e)
        {
            thanh_hien_thi.Lines = new string[] { "", "0" };
        }

        private void Bang(object sender, EventArgs e)
        {
            string bieuthuc = thanh_hien_thi.Lines[1];
            MyStack bieuthuc2 = CaculateHelper.XuLyBieuThuc(bieuthuc); 
            string ketqua = CaculateHelper.TinhBieuThuc(bieuthuc2).ToString();
            string[] result = new string[] { bieuthuc, ketqua };
            thanh_hien_thi.Lines = result;
        }

        private void CaculateForm_Load(object sender, EventArgs e)
        {

        }

        private void thanh_hien_thi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
