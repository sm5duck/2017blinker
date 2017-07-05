﻿namespace BlinkBlink_EyeJoah.FacebookLogin
{
    using System;
    using System.Windows.Forms;
    using Facebook;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;

    public partial class FB_Analyze : Form
    {
        private const string AppId = "842840515831167";
        private const string ExtendedPermissions = "user_about_me,user_posts";
        private string _accessToken;
        private List<String> userInfo;
        private GetFacebookUserData getFacebookUserData;
        private Form trainingFaceForm;

        public FB_Analyze(Form trainingFaceForm)
        {
            InitializeComponent();

            this.trainingFaceForm = trainingFaceForm;
        }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImportAttribute("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);

        #region 마우스로 Form 이동에 관한 변수
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        #endregion

        private void DisplayAppropriateMessage(FacebookOAuthResult facebookOAuthResult)
        {
            if (facebookOAuthResult != null)
            {
                if (facebookOAuthResult.IsSuccess)
                {
                    _accessToken = facebookOAuthResult.AccessToken;
                    var fb = new FacebookClient(facebookOAuthResult.AccessToken);

                    userInfo = new List<String>();
                    getFacebookUserData = new GetFacebookUserData(fb);
                    getFacebookUserData.InitUserProfile();
                    userInfo = getFacebookUserData.getUserInfo;

                    startMainForm();
                }
                else
                {
                    MessageBox.Show(facebookOAuthResult.ErrorDescription);
                }
            }
        }

        private void startMainForm()
        {
            // Form들 숨기고 Timer Stop 시키기
            this.Hide();
            this.trainingFaceForm.Hide();
            FaceTraining.timer.Stop();

            // MainForm 띄우기 
            Form1 mainForm = new Form1(userInfo, _accessToken, trainingFaceForm);
            mainForm.Show();
            mainForm.Activate();
        }
        private void btnFacebookLogin_Click(object sender, EventArgs e)
        {
            var fbLoginDialog = new FB_LoginDialog(AppId, ExtendedPermissions);
            fbLoginDialog.ShowDialog();

            DisplayAppropriateMessage(fbLoginDialog.FacebookOAuthResult);
        }

        
        // 비밀번호 변환
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FaceTraining.timer.Start();
        }
        
    }
}
