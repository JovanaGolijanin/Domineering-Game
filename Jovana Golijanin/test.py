import requests

response = requests.get('http://localhost:5173/VratiIgrace')

response = requests.post('http://localhost:5173/DodajIgraca?ime={promeniljivaIme}&brojIndeksa={brojindeksa}')



if response.status_code == 200:
    print(response.text)
else:
    print('An error occurred')

