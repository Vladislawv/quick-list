function updateGoals(){
    $.ajax({
        url: '/Goal/GetAll/',
        type: 'GET',
        success: function (data) {
            $('#goals').html(data);
        },
        error: function (error) {
            console.log('AJAX request error', error);
        }
    });
}

function showCreateGoalForm() {
    $('#defaultContent').hide();
    $('#createGoalForm').show();

    turnGoHomeButton();
}

function turnGoHomeButton(){
    var createGoalButton = document.getElementById('createGoalButton');
    var goHomeButton = document.getElementById('goHomeButton');

    createGoalButton.style.display = 'none';
    goHomeButton.style.display = 'inline-block';
}

function goHome() {
    location.reload()
}

function updateGoal(){
    var id = $('#updateGoalForm').data('id');
    var title = $('#goalTitle').val();
    var description = $('#goalDescription').val();

    $.ajax({
        url: '/Goal/UpdateById/',
        type: 'PUT',
        data: {
            id: id,
            title: title,
            description: description
        },
        success: function (data) {
            $('#right-content').html(data);
            updateGoals();
            $('#updateGoalForm').trigger('reset');
        },
        error: function (error) {
            console.log('AJAX request error', error);
        }
    });
}

function deleteGoal(){
    var id = $('#updateGoalForm').data('id');

    $.ajax({
        url: '/Goal/DeleteById/',
        type: 'DELETE',
        data: {
            id: id
        },
        success: function () {
            location.reload();
        },
        error: function (error) {
            console.log('AJAX request error', error);
        }
    });
}

function setBackgroundOnClick(clickedElement){
    var links = document.querySelectorAll('.clickable');

    links.forEach(function(link) {
        link.classList.remove('clicked');
    });

    clickedElement.classList.add('clicked');
}

function activateSubmit(){
    document.getElementById('submitButton').removeAttribute('disabled');
}

function updateGoalsUI(goalsUl, sortedGoals){
    sortedGoals.forEach(goal => goalsUl.removeChild(goal));
    sortedGoals.forEach(goal => goalsUl.appendChild(goal));
}

function sortGoals(goals, sortBy, orderBy){
    return goals.sort((a, b) => {
        var firstValue = a.querySelector(sortBy).textContent;
        var secondValue = b.querySelector(sortBy).textContent;

        if (orderBy === 'asc') {
            return firstValue.localeCompare(secondValue);
        } else {
            return secondValue.localeCompare(firstValue);
        }
    });
}

function handleCheckboxClick(event, checkbox){
    event.stopPropagation()

    var id = $(checkbox).closest('.note').data('id');
    var isDone = checkbox.checked;

    $.ajax({
        url: '/Goal/SetIsDoneById/',
        type: 'POST',
        data: {
            id: id,
            isDone: isDone
        },
        success: function () {
            updateGoals();
        },
        error: function (error) {
            console.log('AJAX request error', error);
        }
    });
}

$(document).ready(function () {
    updateGoals();
});

$(document).on('click', '.note', function () {
    var id = $(this).data('id');

    $.ajax({
        url: '/Goal/GetById/',
        type: 'GET',
        data: { id: id },
        success: function (data) {
            $('#right-content').html(data);
            turnGoHomeButton();
        },
        error: function (error) {
            console.log('AJAX request error', error);
        }
    });
});

document.getElementById('sortGoalsForm').addEventListener('submit', function(event) {
    event.preventDefault();

    var sortBy = document.getElementById('sort').value;
    var orderBy = document.getElementById('order').value;
    
    var todoGoalsUl = document.getElementById('todo');
    var todoGoalsArray = Array.from(todoGoalsUl.children);
    
    var sortedTodoGoals = sortGoals(todoGoalsArray, sortBy, orderBy);
    updateGoalsUI(todoGoalsUl, sortedTodoGoals);

    var doneGoalsUl = document.getElementById('done');
    var doneGoalsArray = Array.from(doneGoalsUl.children);
    
    var sortedDoneGoals = sortGoals(doneGoalsArray, sortBy, orderBy);
    updateGoalsUI(doneGoalsUl, sortedDoneGoals);
});

$('#createGoalForm').submit(function (event) {
    event.preventDefault();

    var title = $('#goalTitle').val();
    var description = $('#goalDescription').val();

    $.ajax({
        url: '/Goal/Create/',
        type: 'POST',
        data: {
            title: title,
            description: description
        },
        success: function (data) {
            $('#right-content').html(data);
            updateGoals();
            $('#createGoalForm').trigger('reset');
        },
        error: function (error) {
            console.log('AJAX request error', error);
        }
    });
});