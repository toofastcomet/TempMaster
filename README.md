# TempMaster
TempMaster is a GUI for brewing! It is for monitoring temperature specifically with Go!Temp sensor manufactured by Vernier.  You can set email and sms alerts, and track elapsed time since an alert temperature was reached.
What is it:
This is a VS2012 windows form project in C#.  It integrates with a digital temperature probe, specifically called Go!Temp created and sold by [Vernier](http://www.vernier.com/products/sensors/temperature-sensors/go-temp/).

Why:
It's purpose is to ease and automate measuring temperatures digitally.  I had home beer brewing in mind.

What does it do:
Shows you the current probe temperature of course in big white letters.  Furthermore, you setup your email or phone number for notifications.  When the temperature reaches your alert temperature, the software sends you a email or SMS.  Lastly, it can start a timer when the alert temperature is reached.  It's surprisingly accurate and you don't have to watch whatever your cooking up (beer or distillation).
