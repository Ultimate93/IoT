

/*
PIR   Arduino
Vcc    3.3v    
GND    GND

Buzzer     Arduino 
positive   13
negative   GND

*/
int PIR_input=5; 
int buzzer=13;
void setup() {
pinMode(PIR_input, INPUT);
pinMode(buzzer, OUTPUT);
Serial.begin(9600);
Serial.write("PIR motion detection module\n\n");
}
void loop() {
if(digitalRead(PIR_input) == HIGH) 
{
 digitalWrite(buzzer, HIGH); 
 Serial.println("Person Detected");
 }
else {
digitalWrite(buzzer, LOW); 
 Serial.println("Not detected");
}

delay(2000);
}
