<!-- prettier-ignore -->
# reciPR API

- [reciPR API](#reciPR-api)
  - [Create Meal](#create-meal)
    - [Create Meal Request](#create-meal-request)
    - [Create Meal Response](#create-meal-response)
  - [Get Meal](#get-meal)
    - [Get Meal Request](#get-meal-request)
    - [Get Meal Response](#get-meal-response)
  - [Update Meal](#update-meal)
    - [Update Meal Request](#update-meal-request)
    - [Update Meal Response](#update-meal-response)
  - [Delete Meal](#delete-meal)
    - [Delete Meal Request](#delete-meal-request)
    - [Delete Meal Response](#delete-meal-response)

## Create Meal

### Create Meal Request

```js
POST / Meals;
```

```json
{
	"name": "Sticky Honey Lemon Chicken",
	"description": "30g protein. Winner winner, chicken dinner!",
	"macros": [{ "protein": 30 }, { "calories": 250 }, { "fat": 5 }],
	"duration": 60,
	"tags": ["Dinner", "High Protein", "chicken"],
	"ingredients": [
		"chicken",
		"lemon juice",
		"olive oil",
		"butter",
		"soy sauce",
		"honey",
		"parsley",
		"rice",
		"cilantro"
	],
	"seasoning": ["garlic powder", "cumin", "oregano"],
	"instructions": [
		"Mix chicken, garlic powder, cumin, oregano, lemon juice, olive oil",
		"Wash rice with sieve and pot until water is clear",
		"Start boiling the pot with water and rice inside",
		"Add chicken to pan and cook 10 mins, high heat until sizzling, then remove chicken from pan (keep heat on)",
		"Once rice is boiling, stir for 3 minutes then turn heat off and drain the water",
		"Add butter, minced garlic, oregano, lemon juice, soy sauce, and honey directly into the pan then add the chicken back in on top",
		"Stir together and let simmer on medium heat for 5 mins",
		"Turn heat off, add cilantro on top of chicken"
	]
}
```

### Create Meal Response

```js
201 Created
```

```yml
Location: {{host}}/Meals/{{id}}
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"name": "Sticky Honey Lemon Chicken",
	"description": "30g protein. Winner winner, chicken dinner!",
	"macros": [{ "protein": 30 }, { "calories": 250 }, { "fat": 5 }],
	"duration": 60,
	"tags": ["Dinner", "High Protein", "chicken"],
	"ingredients": [
		"chicken",
		"lemon juice",
		"olive oil",
		"butter",
		"soy sauce",
		"honey",
		"parsley",
		"rice",
		"cilantro"
	],
	"seasoning": ["garlic powder", "cumin", "oregano"]
}
```

## Get Meal

### Get Meal Request

```js
GET /Meals/{{id}}
```

### Get Meal Response

```js
200 Ok
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"name": "Sticky Honey Lemon Chicken",
	"description": "30g protein. Winner winner, chicken dinner!",
	"macros": [{ "protein": 30 }, { "calories": 250 }, { "fat": 5 }],
	"duration": 60,
	"tags": ["Dinner", "High Protein", "chicken"],
	"ingredients": [
		"chicken",
		"lemon juice",
		"olive oil",
		"butter",
		"soy sauce",
		"honey",
		"parsley",
		"rice",
		"cilantro"
	],
	"seasoning": ["garlic powder", "cumin", "oregano"]
}
```

## Update Meal

### Update Meal Request

```js
PUT /Meals/{{id}}
```

```json
{
	"name": "Sticky Honey Lemon Chicken",
	"description": "30g protein. Winner winner, chicken dinner!",
	"macros": [{ "protein": 30 }, { "calories": 250 }, { "fat": 5 }],
	"duration": 60,
	"tags": ["Dinner", "High Protein", "Chicken"],
	"ingredients": [
		"chicken",
		"lemon juice",
		"olive oil",
		"butter",
		"soy sauce",
		"honey",
		"parsley",
		"rice",
		"cilantro"
	],
	"seasoning": ["garlic powder", "cumin", "oregano"]
}
```

### Update Meal Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Meals/{{id}}
```

## Delete Meal

### Delete Meal Request

```js
DELETE /Meals/{{id}}
```

### Delete Meal Response

```js
204 No Content
```
