
from random import randint
from datetime import date, timedelta

TARGET = 8000

data = []
current_date = date.today() + timedelta(days=15)

for i in range(365):
    n = randint(7000, 12000)
    data.append(f'{current_date}:{n}:{TARGET}\n')
    current_date -= timedelta(days=1)

with open('step-data.txt', 'w') as of:
    of.writelines(data)
