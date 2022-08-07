Make sure you have load all the assemblies othewise you may see lot's of error

setup a single runprocess instead a new Process every time
run_process(your.exe arg");

setup a drop down port selectopr
        void getavaialbleports()
        {
            String[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
        }
under selector      
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
            }
            
 circular check box:
 use included cs, toolbox- mycheck
 
 output totally depend on event handler.
 fastboot.exe does not send StandardOutput
 setup a error stream
 RedirectStandardError = true;
get output- yourtexbox.Text = yourtexbox.Text + process.StandardError.ReadToEnd();

masking-
remove all the textbox data
if (str.Contains("error") == true)
                {
                    yourtextbox.Text = ("send your comment" + Environment.NewLine);
                }
keep textbox data and send your comment
if (str.Contains("error") == true)
                {
                    yourtextbox.AppendText("send your comment" + Environment.NewLine);
                }
