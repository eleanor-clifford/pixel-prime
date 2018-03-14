#!/bin/bash
python3 linearPgmToNumber.py
mv perfectNumber.txt possiblePrimes.txt
python3 format.py
libreoffice output.txt
