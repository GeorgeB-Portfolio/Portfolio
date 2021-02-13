TotalEmployees = int(input("How Many employees worked this week? "))
Names = []
NumSold = []
SalesData = []
for i in range(0,TotalEmployees):
    Name = input("What is the name of the employee? ")
    Names.append(Name)
    SalesData.append(Name)
    NumberSold = int(input("How many cars did they sell? "))
    NumSold.append(NumberSold)
    SalesData.append(str(NumberSold))


print(SalesData)

HighestNum = 0
PostionNum = 0

for i in range(0,len(NumSold)):
    try:
        if NumSold[i] > NumSold[i + 1]:
            if HighestNum > NumSold[i]:
                i = i + 1
            else:
                HighestNum = NumSold[i]
                i = i + 1
        elif NumSold[i] < NumSold[i + 1]:
            if HighestNum > NumSold[i + 1]:
                i = i + 1
            else:
                HighestNum = NumSold[i + 1]
                i = i + 1
        
    except:
        break

PositionNum = NumSold.index(HighestNum)

print("The name of the employee with the highest sales this week is",Names[PositionNum] + " they Sold", HighestNum, "cars this week")

TotalNum = 0
for i in range(0,len(NumSold)):
    try:
        TotalNum = TotalNum + NumSold[i]
        i = i + 1
    except:
        break
print("The Total number of cars sold is", TotalNum)

Data = open("Sales Data.txt", "a")
for i in range(0,len(SalesData)):
    try:
        Data.write(str(SalesData[i] + ","))
        SalesData.pop(0)
        Data.write(str(SalesData[i]))
        Data.write("\n")
    except:
        break
Data.close()

