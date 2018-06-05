#include <ESP8266HTTPClient.h>
#include <ESP8266WiFi.h>

const char* ssid = "Novitu Soft Labs";
const char* password = "Nov!@#383";

void setup() {
 
  Serial.begin(115200);         
    pinMode(D5, OUTPUT);
    pinMode(D6, OUTPUT);
   WiFi.begin(ssid, password);
 
  while (WiFi.status() != WL_CONNECTED) {  //Wait for the WiFI connection completion
 
    delay(500);
    Serial.println("Waiting for connection");
 
  }
 Serial.println("Connected..");
 Serial.println("IP address::");
 Serial.print(WiFi.localIP());
 
}
 
void loop() {
  int a;
 if(WiFi.status()== WL_CONNECTED){   //Check WiFi connection status
 
   HTTPClient http;    //Declare object of class HTTPClient
 
   http.begin("http://www.drbawasakar.com/ras.php");      //Specify request destination
   http.addHeader("Content-Type", "text/plain");  //Specify content-type header
 
   int httpCode = http.POST("Message from ESP8266");   //Send the request
   String payload = http.getString();                  //Get the response payload
   if(httpCode > 0)
   {
   Serial.println("\nResponse::\t");
   Serial.println(httpCode);   //Print HTTP return code
   Serial.println("payload::\t");
   Serial.println(payload);    //Print request response payload
    a=payload.toInt();
    //digitalWrite(D5,payload.toInt());
    if(a==1){
      digitalWrite(D5,HIGH);
      }
   }
   else
   {
    Serial.println("Server is not connected");
    }
  http.end();
    
 
 }else{
 
    Serial.println("Error in WiFi connection");   
 
 }
 delay(10000);
 digitalWrite(D5,LOW);
  delay(200000);  //Send a request every 20 seconds
 
}
