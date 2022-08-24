Make sure you have load all the assemblies othewise you may see lot's of error

setup a single runprocess instead a new Process every time

<code>
run_process(your.exe arg");</code>


setup a drop down port selectopr


        void getavaialbleports()
        {
            String[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
        }
under selector

<code>
try
            {
                if (cboPort.Text == "" || cboPort.Text == "")
                {
                    cboPort.Text = "Please select port settings";
                }
                else
                {
                    serialPort1.PortName = cboPort.Text;
                    cboPort.Enabled = true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                cboPort.Text = "Unauthorised Access";
            }</code>
  


circular check box:

use included cs, toolbox- mycheck
 
 output totally depend on event handler.
 fastboot.exe does not send StandardOutput
 setup a error stream
 <code>
 RedirectStandardError = true;</code>
 
 
 get output- <code>yourtexbox.Text = yourtexbox.Text + process.StandardError.ReadToEnd();</code>

masking-
remove all the textbox data & send comment

<code>if (str.Contains("error") == true)
                {
                    yourtextbox.Text = ("send your comment" + Environment.NewLine);
                }</code>

keep textbox data and send your comment

<code>if (str.Contains("error") == true)
                {
                    yourtextbox.AppendText("send your comment" + Environment.NewLine);
                }</code>


**MTK Process:**
Click START button and then Connect

**QCOM Process:**
connect Phone wait for port detection and Click START button

**Fastboot Process:**
Must Connect Phone in fastbot Mod and then Click START button

**Samsung Download:**
connect Phone in download mod, load File click Download
