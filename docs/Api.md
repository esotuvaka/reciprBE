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
	"duration": "60 minutes",
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
	"duration": "60 minutes",
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
	"duration": "60 minutes",
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
	"duration": "60 minutes",
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
