import requests
import json
import time

id_tv_show = 1 # id tv show
genres = []


def get_data(url):
    response_API = requests.get(url)
    data = response_API.text
    return json.loads(data)

def verify_genres(list):
    for genre in list:
        if genre not in genres:
            genres.append(genre)

def insert_list_genres(list, id_tv_show):
    for genre in list:
        list_genres_file = open('insertListGenres.sql', 'a', encoding='utf-8')

        insert_genre = '''
        INSERT INTO ListGenres (id_genre, id_tv_show)
        VALUES({}, {}); \n
        '''.format(genres.index(genre) + 1, id_tv_show) 

        list_genres_file.write(insert_genre)
        list_genres_file.close()       

url_most_popular = 'https://www.episodate.com/api/most-popular?page=1'

json_data = get_data(url_most_popular)
tv_shows = json_data['tv_shows']

for tv_show in tv_shows:
    tv_shows_file = open('insertTvShows.sql', 'a', encoding='utf-8')
    url_show_details = 'https://www.episodate.com/api/show-details?q=' + str(tv_show['id'])
    get_tv_show = get_data(url_show_details)
    tv_show_details = get_tv_show['tvShow']

    insert_tv_show = '''
    INSERT INTO TvShow (title, show_description, show_status, poster)
    VALUES('{}', '{}', '{}', '{}'); \n
    '''.format(tv_show_details['name'], tv_show_details['description'].replace(''', ''' ), tv_show_details['status'], tv_show_details['image_path'])
    
    episode_duration = tv_show_details['runtime']
    tv_show_genres = tv_show_details['genres']
    verify_genres(tv_show_genres)
    insert_list_genres(tv_show_genres, id_tv_show)

    countEp = 1
    for episode in tv_show_details['episodes']:
        episodes_file = open('insertEpisodes.sql', 'a', encoding='utf-8')
        insert_episodes = '''
    INSERT INTO Episodes (id_tv_show, title, duration, season, episode_numb, air_date)
    VALUES({}, '{}', {}, {}, {}, {}); \n
    '''.format(id_tv_show, episode['name'], episode_duration, episode['season'], episode['episode'], episode['air_date'])

        episodes_file.write(insert_episodes)
        print('episodio: {}'.format(countEp))
        countEp += 1
        episodes_file.close()


    print(id_tv_show)
    id_tv_show += 1
    tv_shows_file.write(insert_tv_show)
    tv_shows_file.close()
    time.sleep(150)
        
for g in genres:
    genres_file = open('insertGenres.sql', 'a', encoding='utf-8')

    genres_file.write('''
        INSERT INTO Genres (title)
        VALUES('{}'); \n
    '''.format(g))

    genres_file.close()


