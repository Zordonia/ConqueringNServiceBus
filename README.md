IMPORTANT

I recommend running "lib\NServiceBus.2.1.0.1305\RunMeFirst.bat" first since this installs services (msmq) and 
modifies registry with necessary changes. This must be run as administrator!

If you do not create the queues manually you would also need to run Visual Studio as an administrator. 
When you start debugging NServiceBus will by default create the necessary queues on your system.