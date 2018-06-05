 #include "DHT.h"

#include "SoftwareSerial.h"

#define DHTPIN 7                       // Digital Pin 5

#define DHTTYPE DHT11                  // We are Using DHT11

String apiKey = "IKBFKLDYSP9PAUER";    // Edit this API key according to your Account

String Host_Name = "Tech_D0007680";         // Edit Host_Name

String Password = "VVCPRYMW";          // Edit Password

SoftwareSerial ser(2,3);              // RX, TX

int i=1;

DHT dht(DHTPIN, DHTTYPE);              // Initialising Pin and Type of DHT

void setup() {     
  Serial.begin(115200);                  // enable software serial

ser.begin(115200);           
ser.println("AT+RST");              // Resetting ESP8266
printResponse();
Serial.println("AT+RST"); 
dht.begin();                        // Enabling DHT11

char inv ='"';

String cmd = "AT+CWJAP";

       cmd+= "=";

       cmd+= inv;

       cmd+= Host_Name;

       cmd+= inv;

       cmd+= ",";

       cmd+= inv;

       cmd+= Password;

       cmd+= inv;

ser.println(cmd);                    // Connecting ESP8266 to your WiFi Router
printResponse();
Serial.println(cmd);

  }

// the loop 

void loop() {

  int humidity =  dht.readHumidity();             // Reading Humidity Value

  int temperature = dht.readTemperature(); // Reading Temperature Value
  
  String state1=String(humidity);                 // Converting them to string 

  String state2=String(temperature);              // as to send it through URL

 

  String cmd = "AT+CIPSTART=\"TCP\",\"";          // Establishing TCP connection

// cmd += "184.106.153.149";                       // api.thingspeak.com
 // cmd += "103.21.58.16";
   cmd +="drbawasakar.com";
  cmd += "\",80";                                 // port 80

  ser.println(cmd);
  printResponse();
  Serial.println(cmd);

//ser.println("AT+CIFSR"); 
//Serial.println("AT+CIPSTATUS"); 
//printResponse();

 if(ser.find("Error")){
    Serial.println("AT+CIPSTART error");
    return;
  }
String getStr = "GET /ras.php?";
//String getStr = "GET /update?api_key=";
//String getStr = "GET /ras.php?text=ESP&value=1234\r\nHTTP/1.1\r\nHost:www.drbawasakar.com";
//String getStr = "GET /update?api_key=IKBFKLDYSP9PAUER&field1=10&field2=10\r\n HTTP/1.1\r\n Host:www.api.thingspeak.com";
//String getStr = "GET /ras.php?text=ESP&value=abc HTTP/1.0\r\nHost:www.drbawasakar.com\r\n\r\n";  
  //getStr += apiKey;

   getStr +="field1=";
   getStr += String(state1);                       // Humidity Data

   getStr +="&field2=";
   getStr += String(state2);                       // Temperature Data

  getStr += " HTTP/1.0\r\nHost:www.drbawasakar.com\r\n\r\n";
  
  //getStr += "\r\n\r\n";
  cmd = "AT+CIPSEND=";

  cmd += String(getStr.length());                // Total Length of data

  ser.println(cmd);
  Serial.println(cmd);

if(ser.find(">")){

    ser.print(getStr);
    printResponse();
    Serial.print(getStr);

  }

//  else{

  //  ser.println("AT+CIPCLOSE");                  // closing connection
   // printResponse();
    // alert user

    //Serial.println("AT+CIPCLOSE");

  //}

 delay(3000);                                  // Update after every 10 seconds

}

void printResponse1() {
  String response;
  char c;
  Serial.println("INSIDE printResponse");

  Serial.println("START AVAIL ************************************** ");
  while (ser.available()) {
    c=ser.read(); 
    response +=c;
     
  }
//  Serial.println("END WHILE------------------------------------");
   Serial.println(response);
  Serial.println("END ------------------------------------");
  }
  
void printResponse() {
  Serial.println("INSIDE printResponse");
  while (ser.available()) {
    Serial.println("SER AVAIL");
    Serial.println(ser.readStringUntil('\n')); 
  }
  }
