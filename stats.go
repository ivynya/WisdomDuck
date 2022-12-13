package main

type Stats struct {
	Visits    int
	APIVisits int
	Referrals map[string]struct {
		From      string
		Visits    int
		APIVisits int
	}
}
