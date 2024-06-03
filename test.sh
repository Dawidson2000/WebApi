#!/bin/bash

# Base URL of the API
BASE_URL="https://localhost:7103/Companies"

# Example data for POST and PUT requests
CREATE_COMPANY_JSON='{
  "name": "Example Company",
  "address": "123 Example Street",
  "city": "Example City",
  "country": "Example Country"
}'

UPDATE_COMPANY_JSON='{
  "id": "example-guid", # Replace with a valid GUID
  "name": "Updated Company",
  "address": "456 Updated Street",
  "city": "Updated City",
  "country": "Updated Country"
}'

# GET all companies
echo "GET all companies:"
curl -X GET "$BASE_URL" -H "accept: application/json"
echo -e "\n"

# GET a single company by ID (replace {id} with a valid GUID)
echo "GET single company by ID:"
curl -X GET "$BASE_URL/{id}" -H "accept: application/json"
echo -e "\n"

# POST a new company
echo "POST new company:"
curl -X POST "$BASE_URL" -H "Content-Type: application/json" -d "$CREATE_COMPANY_JSON"
echo -e "\n"

# PUT to update a company (replace {id} with a valid GUID)
echo "PUT update company:"
curl -X PUT "$BASE_URL/{id}" -H "Content-Type: application/json" -d "$UPDATE_COMPANY_JSON"
echo -e "\n"

# DELETE a company by ID (replace {id} with a valid GUID)
echo "DELETE company by ID:"
curl -X DELETE "$BASE_URL/{id}"
echo -e "\n"