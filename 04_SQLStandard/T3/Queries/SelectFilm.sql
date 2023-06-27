select distinct(release_year) from film f;

select distinct(rating) from film f;

select count(*) as total_films, rating from film f group by rating having count(*) > 200;

select 
	c.name,
	sub.rating,
    sub.total_films
from film f 
inner join film_category fc on f.film_id = fc.film_id
inner join category c on fc.category_id = c.category_id
inner join (
select count(*) as total_films, rating from film f group by rating having count(*) > 200
) as sub on f.rating = sub.rating
group by 
	c.name,
	sub.rating,
    sub.total_films
order by 
	sub.total_films