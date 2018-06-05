//SendReceive.ino

#include<SPI.h>
#include<RF24.h>

// CE, CSN pins
RF24 radio(9, 10);

void setup(void){
	while(!Serial);
	Serial.begin(9600);

	radio.begin();
	radio.setPALevel(RF24_PA_MAX);
	radio.setChannel(0x76);
	radio.openWritingPipe(0xE8E8F0F0E1LL);
	const uint64_t pipe = (0xF0F0F0F0E1LL);
	radio.openReadingPipe(1, pipe);

	radio.enableDynamicPayloads();
	radio.powerUp();
	
}

void loop(void){
    const char text[] = "Hello World is awesome";
	radio.write(&text, sizeof(text));
	delay(1000);
 
}