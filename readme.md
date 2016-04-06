# CsvQuery

C# Project loads csv files into memory and performs fast dictionary-based queries

Flow -  
1. enter path to csv as program's argument
2. first cs will be parsed and values will be distributed in an identifier (value[0]) as-key dictionary
3. queries can be made after csv is loaded

This process is limited by the amount of free memory, as it has to be larger than the loaded csv
