
namespace MyTestStream
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerUpdateKline = new System.Windows.Forms.Timer(this.components);
            this.timerStartBot = new System.Windows.Forms.Timer(this.components);
            this.timerUpdateListenKey = new System.Windows.Forms.Timer(this.components);
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxSecretKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonApllyApiKey = new System.Windows.Forms.Button();
            this.buttonStartBot = new System.Windows.Forms.Button();
            this.textBoxCoinName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRangeBars = new System.Windows.Forms.TextBox();
            this.textBoxStartBars = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonApplyParams = new System.Windows.Forms.Button();
            this.textBoxTP = new System.Windows.Forms.TextBox();
            this.textBoxSL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLeverage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPercToSetOrder = new System.Windows.Forms.TextBox();
            this.textBoxPercToCancelOrder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelCoinName = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelLeverage = new System.Windows.Forms.Label();
            this.labelRandeBars = new System.Windows.Forms.Label();
            this.labelTP = new System.Windows.Forms.Label();
            this.labelPercToSetOrder = new System.Windows.Forms.Label();
            this.labelStartBars = new System.Windows.Forms.Label();
            this.labelSL = new System.Windows.Forms.Label();
            this.labelPercToCancelOrder = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelHighPrice = new System.Windows.Forms.Label();
            this.labelLowPrice = new System.Windows.Forms.Label();
            this.labelPercToHigh = new System.Windows.Forms.Label();
            this.labelPercToLow = new System.Windows.Forms.Label();
            this.labelIsStabHigh = new System.Windows.Forms.Label();
            this.labelIsStabLow = new System.Windows.Forms.Label();
            this.listBoxTP_Errors = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listBoxSL_Errors = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.labelCountTP = new System.Windows.Forms.Label();
            this.labelCountSL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listBoxNewStopOrderBuy = new System.Windows.Forms.ListBox();
            this.listBoxNewStopOrderSell = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.listBoxCancelOrder = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.labelDealShortInfo = new System.Windows.Forms.Label();
            this.labelDealLongInfo = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.timerUpdateStreamKlines = new System.Windows.Forms.Timer(this.components);
            this.labelStep = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.labelPriceDouble = new System.Windows.Forms.Label();
            this.labelAfterDor = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerUpdateKline
            // 
            this.timerUpdateKline.Interval = 60000;
            this.timerUpdateKline.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerStartBot
            // 
            this.timerStartBot.Interval = 5000;
            this.timerStartBot.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerUpdateListenKey
            // 
            this.timerUpdateListenKey.Interval = 1800000;
            this.timerUpdateListenKey.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(121, 9);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.PasswordChar = '$';
            this.textBoxApiKey.Size = new System.Drawing.Size(233, 20);
            this.textBoxApiKey.TabIndex = 0;
            this.textBoxApiKey.TabStop = false;
            // 
            // textBoxSecretKey
            // 
            this.textBoxSecretKey.Location = new System.Drawing.Point(121, 35);
            this.textBoxSecretKey.Name = "textBoxSecretKey";
            this.textBoxSecretKey.PasswordChar = '$';
            this.textBoxSecretKey.Size = new System.Drawing.Size(233, 20);
            this.textBoxSecretKey.TabIndex = 0;
            this.textBoxSecretKey.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "APIKEY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SECRET KEY";
            // 
            // buttonApllyApiKey
            // 
            this.buttonApllyApiKey.Location = new System.Drawing.Point(360, 9);
            this.buttonApllyApiKey.Name = "buttonApllyApiKey";
            this.buttonApllyApiKey.Size = new System.Drawing.Size(67, 46);
            this.buttonApllyApiKey.TabIndex = 2;
            this.buttonApllyApiKey.TabStop = false;
            this.buttonApllyApiKey.Text = "Ok";
            this.buttonApllyApiKey.UseVisualStyleBackColor = true;
            this.buttonApllyApiKey.Click += new System.EventHandler(this.buttonApllyApiKey_Click);
            // 
            // buttonStartBot
            // 
            this.buttonStartBot.Location = new System.Drawing.Point(360, 442);
            this.buttonStartBot.Name = "buttonStartBot";
            this.buttonStartBot.Size = new System.Drawing.Size(147, 48);
            this.buttonStartBot.TabIndex = 3;
            this.buttonStartBot.TabStop = false;
            this.buttonStartBot.Text = "Start Bot";
            this.buttonStartBot.UseVisualStyleBackColor = true;
            this.buttonStartBot.Click += new System.EventHandler(this.buttonStartBot_Click);
            // 
            // textBoxCoinName
            // 
            this.textBoxCoinName.Location = new System.Drawing.Point(121, 146);
            this.textBoxCoinName.Name = "textBoxCoinName";
            this.textBoxCoinName.Size = new System.Drawing.Size(96, 20);
            this.textBoxCoinName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Coin Name";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(121, 172);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(96, 20);
            this.textBoxQuantity.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quantity";
            // 
            // textBoxRangeBars
            // 
            this.textBoxRangeBars.Location = new System.Drawing.Point(121, 241);
            this.textBoxRangeBars.Name = "textBoxRangeBars";
            this.textBoxRangeBars.Size = new System.Drawing.Size(96, 20);
            this.textBoxRangeBars.TabIndex = 3;
            // 
            // textBoxStartBars
            // 
            this.textBoxStartBars.Location = new System.Drawing.Point(121, 267);
            this.textBoxStartBars.Name = "textBoxStartBars";
            this.textBoxStartBars.Size = new System.Drawing.Size(96, 20);
            this.textBoxStartBars.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Range Bars";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Start Bars";
            // 
            // buttonApplyParams
            // 
            this.buttonApplyParams.Location = new System.Drawing.Point(121, 462);
            this.buttonApplyParams.Name = "buttonApplyParams";
            this.buttonApplyParams.Size = new System.Drawing.Size(96, 28);
            this.buttonApplyParams.TabIndex = 4;
            this.buttonApplyParams.TabStop = false;
            this.buttonApplyParams.Text = "Apply params";
            this.buttonApplyParams.UseVisualStyleBackColor = true;
            this.buttonApplyParams.Click += new System.EventHandler(this.buttonApplyParams_Click);
            // 
            // textBoxTP
            // 
            this.textBoxTP.Location = new System.Drawing.Point(121, 304);
            this.textBoxTP.Name = "textBoxTP";
            this.textBoxTP.Size = new System.Drawing.Size(96, 20);
            this.textBoxTP.TabIndex = 5;
            // 
            // textBoxSL
            // 
            this.textBoxSL.Location = new System.Drawing.Point(121, 330);
            this.textBoxSL.Name = "textBoxSL";
            this.textBoxSL.Size = new System.Drawing.Size(96, 20);
            this.textBoxSL.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "TP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "SL";
            // 
            // textBoxLeverage
            // 
            this.textBoxLeverage.Location = new System.Drawing.Point(121, 198);
            this.textBoxLeverage.Name = "textBoxLeverage";
            this.textBoxLeverage.Size = new System.Drawing.Size(96, 20);
            this.textBoxLeverage.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Leverage";
            // 
            // textBoxPercToSetOrder
            // 
            this.textBoxPercToSetOrder.Location = new System.Drawing.Point(121, 387);
            this.textBoxPercToSetOrder.Name = "textBoxPercToSetOrder";
            this.textBoxPercToSetOrder.Size = new System.Drawing.Size(96, 20);
            this.textBoxPercToSetOrder.TabIndex = 7;
            // 
            // textBoxPercToCancelOrder
            // 
            this.textBoxPercToCancelOrder.Location = new System.Drawing.Point(121, 413);
            this.textBoxPercToCancelOrder.Name = "textBoxPercToCancelOrder";
            this.textBoxPercToCancelOrder.Size = new System.Drawing.Size(96, 20);
            this.textBoxPercToCancelOrder.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "PercToSetOrder";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 416);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "PercToCancelOrder";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 365);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Формат записи: \"1\" - это \"1%\"";
            // 
            // labelCoinName
            // 
            this.labelCoinName.AutoSize = true;
            this.labelCoinName.Location = new System.Drawing.Point(236, 149);
            this.labelCoinName.Name = "labelCoinName";
            this.labelCoinName.Size = new System.Drawing.Size(59, 13);
            this.labelCoinName.TabIndex = 1;
            this.labelCoinName.Text = "Coin Name";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(236, 175);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(46, 13);
            this.labelQuantity.TabIndex = 1;
            this.labelQuantity.Text = "Quantity";
            // 
            // labelLeverage
            // 
            this.labelLeverage.AutoSize = true;
            this.labelLeverage.Location = new System.Drawing.Point(236, 201);
            this.labelLeverage.Name = "labelLeverage";
            this.labelLeverage.Size = new System.Drawing.Size(52, 13);
            this.labelLeverage.TabIndex = 1;
            this.labelLeverage.Text = "Leverage";
            // 
            // labelRandeBars
            // 
            this.labelRandeBars.AutoSize = true;
            this.labelRandeBars.Location = new System.Drawing.Point(236, 244);
            this.labelRandeBars.Name = "labelRandeBars";
            this.labelRandeBars.Size = new System.Drawing.Size(63, 13);
            this.labelRandeBars.TabIndex = 1;
            this.labelRandeBars.Text = "Range Bars";
            // 
            // labelTP
            // 
            this.labelTP.AutoSize = true;
            this.labelTP.Location = new System.Drawing.Point(236, 307);
            this.labelTP.Name = "labelTP";
            this.labelTP.Size = new System.Drawing.Size(21, 13);
            this.labelTP.TabIndex = 1;
            this.labelTP.Text = "TP";
            // 
            // labelPercToSetOrder
            // 
            this.labelPercToSetOrder.AutoSize = true;
            this.labelPercToSetOrder.Location = new System.Drawing.Point(236, 390);
            this.labelPercToSetOrder.Name = "labelPercToSetOrder";
            this.labelPercToSetOrder.Size = new System.Drawing.Size(84, 13);
            this.labelPercToSetOrder.TabIndex = 1;
            this.labelPercToSetOrder.Text = "PercToSetOrder";
            // 
            // labelStartBars
            // 
            this.labelStartBars.AutoSize = true;
            this.labelStartBars.Location = new System.Drawing.Point(236, 270);
            this.labelStartBars.Name = "labelStartBars";
            this.labelStartBars.Size = new System.Drawing.Size(53, 13);
            this.labelStartBars.TabIndex = 1;
            this.labelStartBars.Text = "Start Bars";
            // 
            // labelSL
            // 
            this.labelSL.AutoSize = true;
            this.labelSL.Location = new System.Drawing.Point(236, 333);
            this.labelSL.Name = "labelSL";
            this.labelSL.Size = new System.Drawing.Size(20, 13);
            this.labelSL.TabIndex = 1;
            this.labelSL.Text = "SL";
            // 
            // labelPercToCancelOrder
            // 
            this.labelPercToCancelOrder.AutoSize = true;
            this.labelPercToCancelOrder.Location = new System.Drawing.Point(236, 416);
            this.labelPercToCancelOrder.Name = "labelPercToCancelOrder";
            this.labelPercToCancelOrder.Size = new System.Drawing.Size(101, 13);
            this.labelPercToCancelOrder.TabIndex = 1;
            this.labelPercToCancelOrder.Text = "PercToCancelOrder";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "High";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Low";
            // 
            // labelHighPrice
            // 
            this.labelHighPrice.AutoSize = true;
            this.labelHighPrice.Location = new System.Drawing.Point(118, 79);
            this.labelHighPrice.Name = "labelHighPrice";
            this.labelHighPrice.Size = new System.Drawing.Size(29, 13);
            this.labelHighPrice.TabIndex = 1;
            this.labelHighPrice.Text = "High";
            // 
            // labelLowPrice
            // 
            this.labelLowPrice.AutoSize = true;
            this.labelLowPrice.Location = new System.Drawing.Point(118, 105);
            this.labelLowPrice.Name = "labelLowPrice";
            this.labelLowPrice.Size = new System.Drawing.Size(27, 13);
            this.labelLowPrice.TabIndex = 1;
            this.labelLowPrice.Text = "Low";
            // 
            // labelPercToHigh
            // 
            this.labelPercToHigh.AutoSize = true;
            this.labelPercToHigh.Location = new System.Drawing.Point(218, 79);
            this.labelPercToHigh.Name = "labelPercToHigh";
            this.labelPercToHigh.Size = new System.Drawing.Size(29, 13);
            this.labelPercToHigh.TabIndex = 1;
            this.labelPercToHigh.Text = "High";
            // 
            // labelPercToLow
            // 
            this.labelPercToLow.AutoSize = true;
            this.labelPercToLow.Location = new System.Drawing.Point(218, 105);
            this.labelPercToLow.Name = "labelPercToLow";
            this.labelPercToLow.Size = new System.Drawing.Size(27, 13);
            this.labelPercToLow.TabIndex = 1;
            this.labelPercToLow.Text = "Low";
            // 
            // labelIsStabHigh
            // 
            this.labelIsStabHigh.AutoSize = true;
            this.labelIsStabHigh.Location = new System.Drawing.Point(310, 79);
            this.labelIsStabHigh.Name = "labelIsStabHigh";
            this.labelIsStabHigh.Size = new System.Drawing.Size(29, 13);
            this.labelIsStabHigh.TabIndex = 1;
            this.labelIsStabHigh.Text = "High";
            // 
            // labelIsStabLow
            // 
            this.labelIsStabLow.AutoSize = true;
            this.labelIsStabLow.Location = new System.Drawing.Point(310, 105);
            this.labelIsStabLow.Name = "labelIsStabLow";
            this.labelIsStabLow.Size = new System.Drawing.Size(27, 13);
            this.labelIsStabLow.TabIndex = 1;
            this.labelIsStabLow.Text = "Low";
            // 
            // listBoxTP_Errors
            // 
            this.listBoxTP_Errors.FormattingEnabled = true;
            this.listBoxTP_Errors.HorizontalScrollbar = true;
            this.listBoxTP_Errors.Location = new System.Drawing.Point(513, 35);
            this.listBoxTP_Errors.Name = "listBoxTP_Errors";
            this.listBoxTP_Errors.Size = new System.Drawing.Size(505, 251);
            this.listBoxTP_Errors.TabIndex = 6;
            this.listBoxTP_Errors.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(512, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Take Profit List Errors";
            // 
            // listBoxSL_Errors
            // 
            this.listBoxSL_Errors.FormattingEnabled = true;
            this.listBoxSL_Errors.HorizontalScrollbar = true;
            this.listBoxSL_Errors.Location = new System.Drawing.Point(1024, 35);
            this.listBoxSL_Errors.Name = "listBoxSL_Errors";
            this.listBoxSL_Errors.Size = new System.Drawing.Size(505, 251);
            this.listBoxSL_Errors.TabIndex = 6;
            this.listBoxSL_Errors.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1023, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Stop Loss List Errors";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(633, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Count TP";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1131, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Count SL";
            // 
            // labelCountTP
            // 
            this.labelCountTP.AutoSize = true;
            this.labelCountTP.Location = new System.Drawing.Point(691, 13);
            this.labelCountTP.Name = "labelCountTP";
            this.labelCountTP.Size = new System.Drawing.Size(52, 13);
            this.labelCountTP.TabIndex = 7;
            this.labelCountTP.Text = "Count TP";
            // 
            // labelCountSL
            // 
            this.labelCountSL.AutoSize = true;
            this.labelCountSL.Location = new System.Drawing.Point(1188, 13);
            this.labelCountSL.Name = "labelCountSL";
            this.labelCountSL.Size = new System.Drawing.Size(51, 13);
            this.labelCountSL.TabIndex = 7;
            this.labelCountSL.Text = "Count SL";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::MyTestStream.Properties.Resources.Benderr;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(360, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 290);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(94, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 20);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(94, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(22, 20);
            this.panel3.TabIndex = 9;
            // 
            // listBoxNewStopOrderBuy
            // 
            this.listBoxNewStopOrderBuy.FormattingEnabled = true;
            this.listBoxNewStopOrderBuy.HorizontalScrollbar = true;
            this.listBoxNewStopOrderBuy.Location = new System.Drawing.Point(513, 349);
            this.listBoxNewStopOrderBuy.Name = "listBoxNewStopOrderBuy";
            this.listBoxNewStopOrderBuy.Size = new System.Drawing.Size(505, 251);
            this.listBoxNewStopOrderBuy.TabIndex = 6;
            this.listBoxNewStopOrderBuy.TabStop = false;
            // 
            // listBoxNewStopOrderSell
            // 
            this.listBoxNewStopOrderSell.FormattingEnabled = true;
            this.listBoxNewStopOrderSell.HorizontalScrollbar = true;
            this.listBoxNewStopOrderSell.Location = new System.Drawing.Point(1024, 349);
            this.listBoxNewStopOrderSell.Name = "listBoxNewStopOrderSell";
            this.listBoxNewStopOrderSell.Size = new System.Drawing.Size(505, 251);
            this.listBoxNewStopOrderSell.TabIndex = 6;
            this.listBoxNewStopOrderSell.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(510, 330);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "New Stop Order BUY";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1021, 330);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 13);
            this.label20.TabIndex = 7;
            this.label20.Text = "New Stop Order SELL";
            // 
            // listBoxCancelOrder
            // 
            this.listBoxCancelOrder.FormattingEnabled = true;
            this.listBoxCancelOrder.HorizontalScrollbar = true;
            this.listBoxCancelOrder.Location = new System.Drawing.Point(513, 648);
            this.listBoxCancelOrder.Name = "listBoxCancelOrder";
            this.listBoxCancelOrder.Size = new System.Drawing.Size(1016, 251);
            this.listBoxCancelOrder.TabIndex = 6;
            this.listBoxCancelOrder.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(512, 622);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Cancel Stop Order";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(968, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(104, 575);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(41, 13);
            this.labelTest.TabIndex = 11;
            this.labelTest.Text = "label22";
            // 
            // labelDealShortInfo
            // 
            this.labelDealShortInfo.AutoSize = true;
            this.labelDealShortInfo.Location = new System.Drawing.Point(14, 596);
            this.labelDealShortInfo.Name = "labelDealShortInfo";
            this.labelDealShortInfo.Size = new System.Drawing.Size(41, 13);
            this.labelDealShortInfo.TabIndex = 11;
            this.labelDealShortInfo.Text = "label22";
            // 
            // labelDealLongInfo
            // 
            this.labelDealLongInfo.AutoSize = true;
            this.labelDealLongInfo.Location = new System.Drawing.Point(247, 596);
            this.labelDealLongInfo.Name = "labelDealLongInfo";
            this.labelDealLongInfo.Size = new System.Drawing.Size(41, 13);
            this.labelDealLongInfo.TabIndex = 11;
            this.labelDealLongInfo.Text = "label22";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 507);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Price";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(67, 507);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 12;
            this.labelPrice.Text = "Price";
            // 
            // timerUpdateStreamKlines
            // 
            this.timerUpdateStreamKlines.Interval = 250;
            this.timerUpdateStreamKlines.Tick += new System.EventHandler(this.timerUpdateStreamKlines_Tick);
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(236, 442);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(35, 13);
            this.labelStep.TabIndex = 12;
            this.labelStep.Text = "STEP";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(121, 439);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(96, 20);
            this.textBoxStep.TabIndex = 8;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(80, 442);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "STEP";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(14, 537);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 12;
            this.label23.Text = "Price";
            // 
            // labelPriceDouble
            // 
            this.labelPriceDouble.AutoSize = true;
            this.labelPriceDouble.Location = new System.Drawing.Point(67, 537);
            this.labelPriceDouble.Name = "labelPriceDouble";
            this.labelPriceDouble.Size = new System.Drawing.Size(31, 13);
            this.labelPriceDouble.TabIndex = 12;
            this.labelPriceDouble.Text = "Price";
            // 
            // labelAfterDor
            // 
            this.labelAfterDor.AutoSize = true;
            this.labelAfterDor.Location = new System.Drawing.Point(357, 517);
            this.labelAfterDor.Name = "labelAfterDor";
            this.labelAfterDor.Size = new System.Drawing.Size(41, 13);
            this.labelAfterDor.TabIndex = 13;
            this.labelAfterDor.Text = "label25";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 462);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 28);
            this.button2.TabIndex = 4;
            this.button2.TabStop = false;
            this.button2.Text = "Calculate Step";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonApplyParams;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 908);
            this.Controls.Add(this.labelAfterDor);
            this.Controls.Add(this.labelPriceDouble);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.labelDealLongInfo);
            this.Controls.Add(this.labelDealShortInfo);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelCountSL);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.labelCountTP);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listBoxNewStopOrderSell);
            this.Controls.Add(this.listBoxSL_Errors);
            this.Controls.Add(this.listBoxCancelOrder);
            this.Controls.Add(this.listBoxNewStopOrderBuy);
            this.Controls.Add(this.listBoxTP_Errors);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonApplyParams);
            this.Controls.Add(this.buttonStartBot);
            this.Controls.Add(this.buttonApllyApiKey);
            this.Controls.Add(this.labelPercToCancelOrder);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelSL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelStartBars);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelPercToSetOrder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelTP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelRandeBars);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelLeverage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelIsStabLow);
            this.Controls.Add(this.labelPercToLow);
            this.Controls.Add(this.labelLowPrice);
            this.Controls.Add(this.labelIsStabHigh);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labelPercToHigh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelHighPrice);
            this.Controls.Add(this.labelCoinName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStep);
            this.Controls.Add(this.textBoxPercToCancelOrder);
            this.Controls.Add(this.textBoxPercToSetOrder);
            this.Controls.Add(this.textBoxSL);
            this.Controls.Add(this.textBoxTP);
            this.Controls.Add(this.textBoxStartBars);
            this.Controls.Add(this.textBoxRangeBars);
            this.Controls.Add(this.textBoxLeverage);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxCoinName);
            this.Controls.Add(this.textBoxSecretKey);
            this.Controls.Add(this.textBoxApiKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerUpdateKline;
        private System.Windows.Forms.Timer timerStartBot;
        private System.Windows.Forms.Timer timerUpdateListenKey;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textBoxSecretKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonApllyApiKey;
        private System.Windows.Forms.Button buttonStartBot;
        private System.Windows.Forms.TextBox textBoxCoinName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRangeBars;
        private System.Windows.Forms.TextBox textBoxStartBars;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonApplyParams;
        private System.Windows.Forms.TextBox textBoxTP;
        private System.Windows.Forms.TextBox textBoxSL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLeverage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPercToSetOrder;
        private System.Windows.Forms.TextBox textBoxPercToCancelOrder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelCoinName;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelLeverage;
        private System.Windows.Forms.Label labelRandeBars;
        private System.Windows.Forms.Label labelTP;
        private System.Windows.Forms.Label labelPercToSetOrder;
        private System.Windows.Forms.Label labelStartBars;
        private System.Windows.Forms.Label labelSL;
        private System.Windows.Forms.Label labelPercToCancelOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelHighPrice;
        private System.Windows.Forms.Label labelLowPrice;
        private System.Windows.Forms.Label labelPercToHigh;
        private System.Windows.Forms.Label labelPercToLow;
        private System.Windows.Forms.Label labelIsStabHigh;
        private System.Windows.Forms.Label labelIsStabLow;
        private System.Windows.Forms.ListBox listBoxTP_Errors;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBoxSL_Errors;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labelCountTP;
        private System.Windows.Forms.Label labelCountSL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox listBoxNewStopOrderBuy;
        private System.Windows.Forms.ListBox listBoxNewStopOrderSell;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListBox listBoxCancelOrder;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labelTest;
        public System.Windows.Forms.Label labelDealShortInfo;
        public System.Windows.Forms.Label labelDealLongInfo;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Timer timerUpdateStreamKlines;
        public System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label labelPriceDouble;
        public System.Windows.Forms.Label labelAfterDor;
        private System.Windows.Forms.Button button2;
    }
}

