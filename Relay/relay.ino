void setup()
{                
    pinMode(2, OUTPUT);  // buzzer on pin 3
}

void loop()
{
   digitalWrite(2, HIGH); // switch buzzer on for 100ms
    delay(10000);
   digitalWrite(2, LOW); // switch buzzer off
    delay(10000);
}
