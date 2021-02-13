Names = ["A","B","C","D","E","F"]
Scores = [55,35,20,70,10,90]
SortedResults = []
LengthSortedResults = 0

Swapped = True
while Swapped == True:
    Swapped = False
    for i in range(0,len(Scores)):
        try:
            if Scores[i] < Scores[i + 1]:
                Scores[i], Scores[i + 1] = Scores[i + 1], Scores[i]
                Names[i], Names[i+1] = Names[i+1],Names[i]
                Swapped = True
        except:
            break


print(Scores)
print(Names)

for i in range(0,len(Scores)):
    try:
        SortedResults.append(Names[i])
        SortedResults.append(Scores[i])
    except:
        break

print(SortedResults)
LengthSortedResult = len(SortedResults)

Data = open("Data.txt", "a")
for i in range(0,LengthSortedResult):
    try:
        Data.write(str(SortedResults[i]))
        Data.write(",")
        SortedResults.pop(0)
        Data.write(str(SortedResults[i]))
        Data.write("\n")

    except:
        break
Data.close()
