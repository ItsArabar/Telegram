min = 3* (10**10)
count = 0

for i in range(2*(10**10), 4*(10**10)):
    k = 0
    l = 0
    if i % 7 == 0:
        if i % 100000 == 0:
            if i % 13 == 0:
                k+=1
            if i % 29 == 0:
                k+=1
            if i % 43 == 0:
                k+=1
            if i % 101 == 0:
                k+=1
        else:
            continue
    else:
        continue
    
    if k == 0:
        count+=1
        if i < min:
            min = i
else:
    print(count,' ', min)
