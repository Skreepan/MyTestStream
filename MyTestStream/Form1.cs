using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTestStream
{
    public partial class Form1 : Form
    {
        private Client client;
        public Form1()
        {
            InitializeComponent();
            client = new Client(this);
        }

        /// <summary>
        /// client.updateKlines();
        /// client.loop();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            client.updateKlines();
            
            updateInfoForCoin();

            
            labelCountSL.Text = client.countSL.ToString();
            labelCountTP.Text = client.countTP.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*client.requestListenKey();
            client.startStreamUpdateOrder();
            timer2.Enabled = false;
            timer1.Enabled = true;
            timer3.Enabled = true; */
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            timerStartBot.Enabled = false;
            timerUpdateKline.Enabled = true;
            timerUpdateListenKey.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            client.startStreamKline();
            client.requestListenKey();
            client.startStreamUpdateOrder();
        }

        /// <summary>
        /// ApiKey Secret Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonApllyApiKey_Click(object sender, EventArgs e)
        {
            if(textBoxApiKey.Text != "")
            {
                client.setApiKey(textBoxApiKey.Text);
                textBoxApiKey.Text = "";
                panel2.BackgroundImage = Properties.Resources.check;
            }

            if(textBoxSecretKey.Text != "")
            {
                client.setSecretKey(textBoxSecretKey.Text);
                textBoxSecretKey.Text = "";
                panel3.BackgroundImage = Properties.Resources.check;
            }
        }

        private void buttonStartBot_Click(object sender, EventArgs e)
        {
            timerUpdateStreamKlines.Enabled = true;
            client.updateKlines();
            updateInfoForCoin();
            client.requestListenKey();
            client.startStreamUpdateOrder();
            client.startStreamKline();
            timerStartBot.Enabled = true;
            buttonStartBot.Enabled = false;
        }

        private void buttonApplyParams_Click(object sender, EventArgs e)
        {
            
            if (textBoxLeverage.Text != "")
            {
                client.setLeverage(int.Parse(textBoxLeverage.Text));
                textBoxLeverage.Text = "";
            }

            if (textBoxCoinName.Text != "")
            {
                client.setCoinName(textBoxCoinName.Text);
                textBoxCoinName.Text = "";
            }

            if(textBoxQuantity.Text != "")
            {
                client.setQuantity(double.Parse(textBoxQuantity.Text.Replace(".", ",")));
                textBoxQuantity.Text = "";
            }

            if(textBoxRangeBars.Text != "")
            {
                client.setRangeBars(int.Parse(textBoxRangeBars.Text));
                textBoxRangeBars.Text = "";
            }

            if(textBoxStartBars.Text != "")
            {
                client.setStartBars(int.Parse(textBoxStartBars.Text));
                textBoxStartBars.Text = "";
            }

            if(textBoxTP.Text != "")
            {
                client.setTP(decimal.Parse(textBoxTP.Text.Replace(".", ",")));
                textBoxTP.Text = "";
            }

            if(textBoxSL.Text != "")
            {
                client.setSL(decimal.Parse(textBoxSL.Text.Replace(".", ",")));
                textBoxSL.Text = "";
            }

            if(textBoxPercToSetOrder.Text != "")
            {
                client.setPercToSetOrder(decimal.Parse(textBoxPercToSetOrder.Text.Replace(".", ",")));
                textBoxPercToSetOrder.Text = "";
            }

            if(textBoxPercToCancelOrder.Text != "")
            {
                client.setPercToCancelOrder(decimal.Parse(textBoxPercToCancelOrder.Text.Replace(".", ",")));
                textBoxPercToCancelOrder.Text = "";
            }
            
            if (client.getApiKey() != "")
            {
                panel2.BackgroundImage = Properties.Resources.check;
            }

            if(client.getSecretKey() != "")
            {
                panel3.BackgroundImage = Properties.Resources.check;
            }

            if(textBoxStep.Text != "")
            {
                client.setStep(decimal.Parse(textBoxStep.Text.Replace(".", ",")));
                textBoxStep.Text = "";
            }
            updateParam();
            client.checkStep();
        }

        private void updateParam()
        {
            labelCoinName.Text = client.getNameCoin();
            this.Text = client.getNameCoin();
            labelQuantity.Text = client.getQuantity().ToString();
            labelLeverage.Text = client.getLeverage().ToString();
            labelRandeBars.Text = client.getRangeBars().ToString();
            labelStartBars.Text = client.getStartBars().ToString();
            labelTP.Text = client.getTP().ToString()+"%";
            labelSL.Text = client.getSL().ToString()+"%";
            labelPercToSetOrder.Text = client.getPercToSetOrder().ToString()+"%";
            labelPercToCancelOrder.Text = client.getPercToCancelOrder().ToString()+"%";
            labelStep.Text = client.getStep().ToString();
        }

        private void updateInfoForCoin()
        {
            labelHighPrice.Text = client.getLevelsHL().getHigh().ToString();
            labelLowPrice.Text = client.getLevelsHL().getLow().ToString();
            labelPercToHigh.Text = client.getPercToHigh().ToString("0.##");
            labelPercToLow.Text = client.getPercToLow().ToString("0.##");
            labelIsStabHigh.Text = client.getLevelsHL().checkIsStabHigh().ToString();
            labelIsStabLow.Text = client.getLevelsHL().checkIsStabLow().ToString();
        }

        private void clearListSL()
        {
            for(int i=listBoxSL_Errors.Items.Count-1; i > -1; i--)
            {
                listBoxSL_Errors.Items.RemoveAt(i);
            }
        }

        private void clearListTP()
        {
            for (int i = listBoxTP_Errors.Items.Count - 1; i > -1; i--)
            {
                listBoxTP_Errors.Items.RemoveAt(i);
            }
        }

        private void clearListNewStopOrderBuy()
        {
            for(int i = listBoxNewStopOrderBuy.Items.Count -1; i > -1; i--)
            {
                listBoxNewStopOrderBuy.Items.RemoveAt(i);
            }
        }

        private void clearListNewStopOrderSell()
        {
            for (int i = listBoxNewStopOrderSell.Items.Count - 1; i > -1; i--)
            {
                listBoxNewStopOrderSell.Items.RemoveAt(i);
            }
        }

        private void clearListCancelOrder()
        {
            for (int i = listBoxCancelOrder.Items.Count - 1; i > -1; i--)
            {
                listBoxCancelOrder.Items.RemoveAt(i);
            }
        }

        private void updateListSL()
        {
            for(int i = 0; i < client.list_stopLossErrors.Count; i++)
            {
                listBoxSL_Errors.Items.Add(client.list_stopLossErrors[i]);
            }
        }

        private void updateListTP()
        {
            for(int i =0; i < client.list_TakeProfitErrors.Count; i++)
            {
                listBoxTP_Errors.Items.Add(client.list_TakeProfitErrors[i]);
            }
        }

        private void updateListNewStopOrderBuy()
        {
            for(int i = 0; i < client.list_newStopOrderBuy.Count; i++)
            {
                listBoxNewStopOrderBuy.Items.Add(client.list_newStopOrderBuy[i]);
            }
        }

        private void updateListNewStopOrderSell()
        {
            for (int i = 0; i < client.list_newStopOrderSell.Count; i++)
            {
                listBoxNewStopOrderSell.Items.Add(client.list_newStopOrderSell[i]);
            }
        }

        private void updateListCancelOrder()
        {
            for (int i = 0; i < client.list_cancelStopOrder.Count; i++)
            {
                listBoxCancelOrder.Items.Add(client.list_cancelStopOrder[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearListSL();
            clearListTP();
            updateListSL();
            updateListTP();

            clearListNewStopOrderBuy();
            clearListNewStopOrderSell();
            clearListCancelOrder();
            updateListNewStopOrderBuy();
            updateListNewStopOrderSell();
            updateListCancelOrder();
        }

        private void timerUpdateStreamKlines_Tick(object sender, EventArgs e)
        {
            if (client.getDataKline() != null)
            {
                labelPrice.Text = client.getDataKline().c.ToString();
                client.updatePercToHigh();
                client.updatePercToLow();
            }
            client.loop();
            updateInfoForCoin();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.checkStep();
        }
    }
}
