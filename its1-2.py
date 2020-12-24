min = 22000
count = 0

for i in range(11000, 22000):
    k = 0
    if i % 11 == 0:
        k+=1
    if i % 13 == 0:
        k+=1
    if i % 17 == 0:
        k+=1
    if i % 19 == 0:
        k+=1
    if k == 2:
        count+=1
        if i < min:
            min = i
else:
    print(count,' ', min)
