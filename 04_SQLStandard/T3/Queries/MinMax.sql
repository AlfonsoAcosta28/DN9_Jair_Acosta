select count(*), actor_id from film_actor group by actor_id;


select 
	"Mayor cantidad" query_type,
	sub2.total_films,
    a.actor_id,
    a.first_name,
    a.last_name
 from
	(
	select max(total_films) max_films
	from 
	(
		select count(*) total_films, actor_id from film_actor group by actor_id
	) sub
) sub_max
inner join
(
	select count(*) total_films, actor_id from film_actor group by actor_id
)sub2 on sub_max.max_films = sub2.total_films
inner join actor a on a.actor_id = sub2.actor_id
union
select 
	"Menor cantidad" query_type,
	sub2.total_films,
    a.actor_id,
    a.first_name,
    a.last_name
 from
	(
	select min(total_films) max_films
	from 
	(
		select count(*) total_films, actor_id from film_actor group by actor_id
	) sub
) sub_max
inner join
(
	select count(*) total_films, actor_id from film_actor group by actor_id
)sub2 on sub_max.max_films = sub2.total_films
inner join actor a on a.actor_id = sub2.actor_id;