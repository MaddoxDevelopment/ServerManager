API to combine all cloud API's into a single one.

The project was made for a demonstration to show a decent way to write a new application that may have 3rd party API dependencies.

The main idea here is to reduce coupling between services and have the ability to switch out implementations with ease.

Configuration is not included in the repo, you must add your own api key and project id to appsettings.json.

A UI was originally going to be added to show how to use the API routes, but ran out of time.

Steps:

1) Send GET to /api/facilities/list?provider=packet to retrieve a list of possible facilities for your project.

Choose a the facility you want to use and copy the code given in the response.

```
{
        "id": "4b666a29-a0a7-4426-a245-cc750c104c47",
        "name": "Pittsburgh, PA",
        "code": "pit1",
        "features": null,
        "address": {
            "href": "#1399d9d9-aa3b-43cd-aba2-cda21a53ddee"
        },
        "ipRanges": null
    }
```

2) Send GET to /api/facilities/plans?provider=packet&facility=pit1 to retrieve possible plans for that facility.

```
{
        "id": "d2829bc4-4c00-461c-9125-ec8cefb609f5",
        "slug": "baremetal_2a4",
        "name": "Type 2A4",
        "description": "Our Type 2A4 configuration is a 56-core dual socket ARM server.",
        "line": "baremetal"
}
```

Save the slug if the one you would like to use.

3) Send GET to /api/deployment/operatingSystems?provider=packet&plan=baremetal_2a4 to retrieve a list of operating systems
you may provision with.

```
{
        "id": null,
        "slug": "debian_8",
        "name": "Debian 8",
        "distro": "debian",
        "version": "8",
        "preinstallable": false,
        "pricing": null,
        "licensed": false
}
```
Save that slug for the next step.

4) Send a POST request to /api/deployment/deployRandom?provider=packet with the following json body to deploy a device.

```
{
	"locationId" : FACILITY_CODE,
	"planId" : PLAN_SLUG,
	"operatingSystemId" : OS_SLUG
}
```

5) Send a GET request to /api/deployment/devices to get the list of deployed devices.

6) Send a DELETE request to /api/deployment/remove?provider=packet&deviceId=DEVICE_ID to remove the deployed device

----------------

Possible refactoring / cleanup to be done.

1) Pass ServerProvider through the URL instead of a query parameter, then we could make a provider service to pull that server provider
we want to use right from the IHttpContextAccessor, instead of passing it throughout all the parameters in methods.
    





