using System.Windows.Forms;

namespace DesignPattern_Calculator
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        bool bOperate = false;
        /// <summary>
        /// 工厂类实例
        /// </summary>
        OperationLibrary.Operation oper;
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 所有的数字和运算符按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNum_Click(object sender, System.EventArgs e)
        {
            if (bOperate)
            {
                txtShow.Text = "";
                bOperate = false;
            }
            string number = ((Button)sender).Text;

            txtShow.Text = OperationLibrary.Operation.CheckNumberInput(txtShow.Text, number);
        }

        private void buttonOperation_Click(object sender, System.EventArgs e)
        {
            if (txtShow.Text != "")
            {
                oper = OperationLibrary.OperationFactory.createOperate(((Button)sender).Text);

                oper.NumberA = System.Convert.ToDouble(txtShow.Text);

                bOperate = true;
            }
        }

        private void buttonEqual_Click(object sender, System.EventArgs e)
        {
            if (txtShow.Text != "")
            {
                if (((Button)sender).Text != "=")
                {
                    oper = OperationLibrary.OperationFactory.createOperate(((Button)sender).Text);
                }

                oper.NumberB = System.Convert.ToDouble(txtShow.Text);


                txtShow.Text = oper.GetResult().ToString();
                bOperate = true;
            }
        }

        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            txtShow.Text = "";
        }
    }
}
