# HelloWorldApp

This repository uses GitHub Actions for build and test. The Actions results
show up as **check runs**, not as **commit statuses**. The endpoint you tried:

```
GET /repos/{owner}/{repo}/commits/{ref}/status
```

returns **only** statuses created via the Statuses API. If nothing has posted a
status for that commit, the response is still `200` but has
`"total_count": 0` and `"statuses": []`, which can look like "not working".

## Query commit statuses (legacy Statuses API)

Use the full SHA and optional authentication to avoid rate limits:

```
curl \
  -H "Accept: application/vnd.github+json" \
  -H "X-GitHub-Api-Version: 2022-11-28" \
  -H "Authorization: Bearer $GITHUB_TOKEN" \
  https://api.github.com/repos/miryamGSM/HelloWorldApp/commits/716683bc1e1ef7ae6fe020808adf46e667881cd5/status
```

## Query GitHub Actions results (Checks API)

GitHub Actions publishes check runs. Use the Checks API instead:

```
curl \
  -H "Accept: application/vnd.github+json" \
  -H "X-GitHub-Api-Version: 2022-11-28" \
  -H "Authorization: Bearer $GITHUB_TOKEN" \
  "https://api.github.com/repos/miryamGSM/HelloWorldApp/commits/716683bc1e1ef7ae6fe020808adf46e667881cd5/check-runs"
```

## (Optional) Create a commit status

If you want `/status` to return something, you must post a status:

```
curl -X POST \
  -H "Accept: application/vnd.github+json" \
  -H "X-GitHub-Api-Version: 2022-11-28" \
  -H "Authorization: Bearer $GITHUB_TOKEN" \
  https://api.github.com/repos/miryamGSM/HelloWorldApp/statuses/716683bc1e1ef7ae6fe020808adf46e667881cd5 \
  -d '{"state":"success","context":"ci/example","description":"Example status"}'
```
