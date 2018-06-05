/*
  SD card read/write and delete::
 The circuit:
 * SD card attached to SPI bus as follows:
  
 ** MOSI - pin 11/50
 ** MISO - pin 12/51
 ** CLK - pin 13/52
 ** CS - pin 4 /53
Chnage pin number of CS pin
 */

#include <SPI.h>
#include <SD.h>
#define cs 53
File myFile;

void setup() {
  // Open serial communications and wait for port to open:
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }


  Serial.print("Initializing SD card...");

  if (!SD.begin(cs)) {
    Serial.println("initialization failed!");
    return;
  }
  Serial.println("initialization done.");
  Serial.println("List of Files::");
  myFile = SD.open("/");

  printDirectory(myFile, 0);

  Serial.println("List is done!");

  // open the file. note that only one file can be open at a time,
  // so you have to close this one before opening another.
  myFile = SD.open("testMEGA.txt", FILE_WRITE);

  // if the file opened okay, write to it:
  if (myFile) {
    Serial.print("Writing to testMEGA.txt...");
    myFile.println("Hello Novitu Soft Lab....");
    // close the file:
    myFile.close();
    Serial.println("Writting is done.");
  } else {
    // if the file didn't open, print an error:
    Serial.println("error opening testMEGA.txt");
  }

  // re-open the file for reading:
  myFile = SD.open("testMEGA.txt");
  if (myFile) {
    Serial.println("opening testMEGA.txt:");

    // read from the file until there's nothing else in it:
    while (myFile.available()) {
      Serial.write(myFile.read());
    }
    // close the file:
    myFile.close();
  } else {
    // if the file didn't open, print an error:
    Serial.println("error opening testMEGA.txt");
  }
 /* 
if (SD.exists("testMEGA.txt")) {
    Serial.println("testMEGA.txt exists.");
  } else {
    Serial.println("testMEGA.txt doesn't exist.");
  }

  // delete the file:
  Serial.println("Removing testMEGA.txt...");
  SD.remove("testMEGA.txt");

if (SD.exists("testMEGA.txt")) {
    Serial.println("testMEGA.txt is not removed");
  } else {
    Serial.println("testMEGA.txt successfully removed");
  }
*/
}


void loop() {
  
}

void printDirectory(File dir, int numTabs) {
  while (true) {

    File entry =  dir.openNextFile();
    if (! entry) {
      // no more files
      break;
    }
    for (uint8_t i = 0; i < numTabs; i++) {
      Serial.print('\t');
    }
    Serial.print(entry.name());
    if (entry.isDirectory()) {
      Serial.println("/");
      printDirectory(entry, numTabs + 1);
    } else {
      // files have sizes, directories do not
      Serial.print("\t\tSize::");
      Serial.println(entry.size(), DEC);
    }
    entry.close();
  }
}

