/*
  Arduino Webserver using Serial1
  Displays temperature in a webpage

  Arduino Mega has three Serial communication ports,this code works well with 
  Arduino Mega.For UNO users,use Softserial library to connect Serial1 with
  Arduino UNO 
  If you're unsure about your Arduino model or its pin cofigurations,please check
  the documentation at http://www.arduino.cc
 
  modified August 2016
  By Joyson Chinta and Gladson Kujur
 */
#include<SoftwareSerial.h>
#include<dht.h>
#define DEBUG true
SoftwareSerial Serial1(2,3);
dht DHT;
//Constants
#define DHT11_PIN 7     // DHT 22  (AM2302) - what pin we're connected to

//Variables
float hum;  //Stores humidity value
float temp; //Stores temperature value

void setup()
{
  Serial.begin(115200);    ///////For Serial monitor 
  Serial1.begin(115200); ///////ESP Baud rate
  pinMode(11,OUTPUT);    /////used if connecting a LED to pin 11
  digitalWrite(11,LOW);
 
  sendData("AT+RST\r\n",2000,DEBUG); // reset module
  sendData("AT+CWMODE=3\r\n",1000,DEBUG); // configure as access point
  sendData("AT+CIFSR\r\n",1000,DEBUG); // get ip address
 // sendData("AT+CIPMUX=1\r\n",1000,DEBUG); // configure for multiple connections
//  sendData("AT+CIPSERVER=1,80\r\n",1000,DEBUG); // turn on server on port 80
}


float sensetemp() ///////function to sense temperature.
 {
  int val = analogRead(A0);
  float mv = ( val/1024.0)*5000; 
  float celcius = mv/10;
  return(celcius);
 }
 
int connectionId;
void loop()
{
 int chk = DHT.read11(DHT11_PIN);
    //Read data and store it to variables hum and temp
    hum = DHT.humidity;
    temp= DHT.temperature;
    //Print temp and humidity values to serial monitor
   // Serial.print("Humidity: ");
   // Serial.print(hum);
   // Serial.print(" %, Temp: ");
    //Serial.print(temp);
    //Serial.println(" Celsius");*/
  if(Serial1.available())
  {
    /////////////////////Recieving from web browser to toggle led
    if(Serial1.find("+IPD,"))
    {
     delay(300);
     connectionId = Serial1.read()-48;
     if(Serial1.find("pin="))
     { 
     Serial.println("recieving data from web browser");
     int pinNumber = (Serial1.read()-48)*10; 
     pinNumber += (Serial1.read()-48); 
     digitalWrite(pinNumber, !digitalRead(pinNumber));
     }
   
    /////////////////////Sending data to browser
    else
    {
      String webpage = "<h1>Hello World</h1>";
      espsend(webpage);
     }
    
     if(sensetemp() != 0)
     {
       String add1="<h4>Temperature=</h4>";
     // String two =  String(sensetemp(), 3);
      String two =  String(temp,3);
      add1+= two;
      add1+="&#x2103";   //////////Hex code for degree celcius
      espsend(add1);
      
     }
    
     else
     {
      String c="sensor is not conneted";
      espsend(c);                                     
     } 
     
     String closeCommand = "AT+CIPCLOSE=";  ////////////////close the socket connection////esp command 
     closeCommand+=connectionId; // append connection id
     closeCommand+="\r\n";
     sendData(closeCommand,3000,DEBUG);
    }
  }
}
 
  //////////////////////////////sends data from ESP to webpage///////////////////////////
 
 void espsend(String d)
         {
             String cipSend = " AT+CIPSEND=";
             cipSend += connectionId; 
             cipSend += ",";
             cipSend +=d.length();
             cipSend +="\r\n";
             sendData(cipSend,1000,DEBUG);
             sendData(d,1000,DEBUG); 
         }

//////////////gets the data from esp and displays in serial monitor///////////////////////         
String sendData(String command, const int timeout, boolean debug)
            {
                String response = "";
                Serial1.print(command);
                long int time = millis();
                while( (time+timeout) > millis())
                {
                   while(Serial1.available())
                      {
                         char c = Serial1.read(); // read the next character.
                         response+=c;
                      }  
                }
                
                if(debug)
                     {
                     Serial.print(response); //displays the esp response messages in arduino Serial monitor
                     }
                return response;
            }
