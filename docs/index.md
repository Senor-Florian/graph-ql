# GraphQL

## Bevezetés

A GraphQL egy nagyon hasznos cucc, melynek segítéségvel a frontend döntheti el, hogy mit szeretne megkapni
a szervertől. Ennek előnye, hogy a hívások számát, és a felesleges adatforgalmat is csökkenteni lehet.

## Felépítése

Alapja a schema, melyet kétféleképpen definiálhatunk: schema-first és code-first megközelítés.
3 különböző műveletet engedélyez:

* query
* mutation
* subscription
	
## Implementáció

Itt egy random kódrészlet látható:

```
public FieldType GetClients()
{
	return FieldAsync<ListGraphType<ClientType>>("clients",
		arguments: new QueryArguments(new List<QueryArgument>
		{
			new QueryArgument<IntGraphType> { Name = "year" }
		}),
		resolve: async context =>
		{
			var data = await _clientRepo.ListAsync();

			var createdYear = context.GetArgument<int?>("year");
			if (createdYear.HasValue)
			{
				return data.Where(x => x.Created.Year == createdYear);
			}

			return data;
		});
}
```
	
## Query

A következő képen egy query felépítése látható.

![Query](query.jpg)

## Referenciák

[Tovább a referenciákra](references.md)


