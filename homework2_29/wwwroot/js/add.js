$(() => {
    let x = 1;
    $("#add-rows").on('click', function () {
        $("#ppl-rows").append(`<div id="ppl-rows">
                <div class="row person-row" style="margin-bottom: 10px;">
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[${x}].firstname" placeholder="First Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[${x}].lastname" placeholder="Last Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="people[${x}].age" placeholder="Age" />
                    </div>
                </div>

            </div>`)
        x++;
    });
    });
