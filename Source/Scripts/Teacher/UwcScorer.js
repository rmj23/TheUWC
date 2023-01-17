
function main(continuum) {
    var self = this; //to preserve object for button clicks
    this.CO = "#TheUniversalWritingContinuum";
    this.Continuum = continuum;
    this.Continuum.Statuses = {
        Incomplete: 'category-status glyphicon glyphicon-remove',
        Complete: 'category-status glyphicon glyphicon-ok'
    };
    this.Continuum.NoGuidelineMessage = "There are no criteria at this level"

    /**
	 * This function returns the rowHeight for each category
	 * @returns {number} the height in pixels of each category div
	 */
    this.RowHeight = function () {
        var fullHeight = $('#NavPanel').height();
        return fullHeight / this.Continuum.EvaluationTypes.length;
    }

    /**
	 * This function returns the index of the active category
	 * Maps to an index of self.Continuum.data
	 * @returns {number} the index of the current category
	 */
    this.ActiveEvalTypeIndex = function () {
        return $('.category.active').index();
    }

    /**
	 * Fixes out of range meta index
	 * Assumes a five proficiency view
	 */
    this.ValidateIndexFiveColumn = function () {
        if (self.Continuum.Meta.Index < 2) {
            self.Continuum.Meta.Index = 2;
        }
        if (self.Continuum.Meta.Index > self.Continuum.Data.length - 3) {
            self.Continuum.Meta.Index = self.Continuum.Data.length - 3;
        }
    }

    this.ValidateIndexThreeColumn = function () {
        if (self.Continuum.Meta.Index < 1) {
            self.Continuum.Meta.Index = 1;
        }
        if (self.Continuum.Meta.Index > self.Continuum.Data.length - 2) {
            self.Continuum.Meta.Index = self.Continuum.Data.length - 2;
        }
    }

    this.DisableColumnButtons = function (colIndex) {
        $($($('.continuumColumn').get(colIndex)).find('.evaluate')).attr('disabled', 'disabled');
    }

    /**
	 * This function retrieves the text data for a proficiency column
	 * @param index {number} number between 1 and 5 indicating column index
	 * @returns {object} containing proficiency information to display
	 */
    this.GetProficiencyDescription = function (index) {
        var diff = index - self.Continuum.Meta.ProficientLevel;
        var plindex = 0;
        if (diff < -1) {
            plindex = 0;
        }
        else if (diff > 2) {
            plindex = 4;
        }
        else {
            plindex = diff + 2;
        }
        return self.Continuum.Meta.Proficiencies[plindex];
    }

    /**
     * This function retrieves the text data for a proficiency column
     * @param index {number} number between 1 and 5 indicating column index
     * @returns {number} containing proficiencyLevelID
     */
    this.GetProficiencyID = function (index) {
        var diff = index - self.Continuum.Meta.ProficientLevel;
        var plindex = 0;
        if (diff < -1) {
            plindex = 0;
        }
        else if (diff > 2) {
            plindex = 4;
        }
        else {
            plindex = diff + 2;
        }
        return plindex;
    }

    /**
	 * This function gets an array of data to be displayed in all columns
     * Output = {[
     *  { profDesc  : {string} The proficiency level for this piece (Below Basic, Basic, etc.)
     *    profLett  : {string} The letter of the proficiency (A-N)
     *    timeframe : {string} The time for which this proficiency is proficient
     *    guideline : {string} The piece of the continuum for this column
     * ]}
	 * @returns {object} array of data to be displayed in columns
	 */
    this.GetDisplayDataFiveColumn = function () {
        self.ValidateIndexFiveColumn();
        var output = [];
        for (var i = 0; i < 5; i++) {
            var newobj = {};
            var colindex = self.Continuum.Meta.Index + i - 2;
            newobj.profDesc = self.GetProficiencyDescription(colindex);
            newobj.profLett = self.Continuum.Data[colindex].Header.Letter;
            newobj.timeframe = self.Continuum.Data[colindex].Header.Description;
            newobj.guideline = self.Continuum.Data[colindex].Guidelines[self.ActiveEvalTypeIndex()];
            output.push(newobj);
        }
        return output;
    }

    this.GetDisplayDataThreeColumn = function () {
        self.ValidateIndexThreeColumn();
        var output = [];
        for (var i = 0; i < 3; i++) {
            var newobj = {};
            var colindex = self.Continuum.Meta.Index + i - 1;
            newobj.profDesc = self.GetProficiencyDescription(colindex);
            newobj.profLett = self.Continuum.Data[colindex].Header.Letter;
            newobj.timeframe = self.Continuum.Data[colindex].Header.Description;
            newobj.guideline = self.Continuum.Data[colindex].Guidelines[self.ActiveEvalTypeIndex()];
            output.push(newobj);
        }
        return output;
    }

    /**
	 * This function refreshes the view
	 */
    this.BindContent = function () {
        var typeIndex = this.ActiveEvalTypeIndex();
        var currentData = self.GetDisplayDataThreeColumn();
        for (var i = 0; i < 3; i++) {
            var j = i;
            $($('.continuumLevel').get(j)).html(currentData[i].profLett);
            $($('.continuumTimeframe').get(j)).html(currentData[i].timeframe);
            $($('.profLevel').get(j)).html(currentData[i].profDesc);
            var descriptionText = currentData[i].guideline;
            if (!descriptionText) {
                descriptionText = self.Continuum.NoGuidelineMessage;
                self.DisableColumnButtons(i);
            }
            $($('.continuumDescription').get(j)).html(descriptionText + '<br /><br />');
        }
        //show submissions
        $('.category').each(function () {
            var catIndex = $(this).index();
            if (self.Continuum.submission[catIndex].gradeLetter != null) {
                //no submission yet, bind nonsubmission graphic to category div (greenlight)
            }
            else {
                //set 
            }
        })
    }

    /**
	 * This function navigates the index to the left and refreshes the view
	 */
    this.NavTypeLeft = function () {
        if (self.Continuum.Meta.Index > 1) {
            self.Continuum.Meta.Index -= 1;
            self.BindContent();
        }
    }

    /**
	 * This function navigates the index to the right and refreshes the view
	 */
    this.NavTypeRight = function () {
        if (self.Continuum.Meta.Index < self.Continuum.Data.length - 1) {
            self.Continuum.Meta.Index += 1;
            self.BindContent();
        }
    }

    /**
     * This method updates the Continuum's submission object to reflect the user's choice
     * @param evalTypeIndex {number} the index of the current evaluation type (Ideas/Content, Structure, etc.)
     * @param colIndex {number} the index of the column from the evaluation component, maps to proficiency level
     * @param gradeNumber {number} number between 1 and 3 for the sub-grade
     */
    this.UpdateSubmission = function (colIndex, gradeNumber) {
        var evalTypeIndex = self.ActiveEvalTypeIndex();
        var a = self.Continuum.Meta.Index + colIndex - 1;
        this.Continuum.submission[evalTypeIndex].gradeLetter = self.Continuum.Data[a].Header.Letter;
        this.Continuum.submission[evalTypeIndex].gradeNumber = gradeNumber;
        this.Continuum.submission[evalTypeIndex].proficiencyTypeID = self.GetProficiencyID(colIndex) + 1;
        $('.active>.category-status').addClass(function (index, currentClass) {
            if (currentClass == self.Continuum.Statuses.Incomplete) {
                $(this).removeClass();
                return self.Continuum.Statuses.Complete;
            }
            return undefined;
        });
        $('#SubmissionJson').val(JSON.stringify(self.Continuum.submission));
    }

    /**
     *This function binds category names from the data object to the view
     */
    this.bindCategoryText = function () {
        $('.category').each(function () {
            $(this).html('<h4 class="' + self.Continuum.Statuses.Incomplete + '"></h4><br />' + self.Continuum.EvaluationTypes[$(this).index()]);
        });
    }

    this.GetNavLeftPosition = function () {
        var y = $("#theUniversalWritingContinuum").height();
        var x = $("#theUniversalWritingContinuum").width();
        var output = {
            x: undefined,
            y: undefined
        };
        output.x = $('.bhoechie-tab-menu').width();
        output.y = y * (2 / 9);
        return output;
    }

    this.GetNavRightPosition = function () {
        var y = $("#theUniversalWritingContinuum").height();
        var x = $("#theUniversalWritingContinuum").width();
        console.log(x);
        var output = {
            x: undefined,
            y: undefined
        };
        output.x = 0;
        output.y = y * (2/9);
        return output;
    }

    this.Init = function () {
        //enable category toggling
        $('.category').each(function () {
            $(this).click(function () {
                $('#categoryPanel>div.active').removeClass('active');
                $(this).addClass('active');
                self.BindContent();
            });
        });

        //enable submission
        $('.evaluate').each(function () {
            $(this).click(function () {
                self.UpdateSubmission($(this).parent().parent().index(), $(this).attr('value'));
            })
        });

        //Makes first row active
        $('.category').first().addClass('active');

        //Initialize Submission object
        self.Continuum.submission = []
        for (var i = 0; i < self.Continuum.EvaluationTypes.length; i++) {
            var a = {};
            a.evalTypeIndex = i+1;
            a.gradeLetter = null;
            a.gradeNumber = null;
            a.proficiencyTypeID = null;
            self.Continuum.submission.push(a);
        }
        $('#SubmissionJson').val(JSON.stringify(self.Continuum.submission));

        //Init Navigation
        $('#NavLeft').click(self.NavTypeLeft);
        $('#NavRight').click(self.NavTypeRight);
        var nleft = self.GetNavLeftPosition();
        $('.btn-continuum-float-left').css('top', nleft.y);
        $('.btn-continuum-float-left').css('left', nleft.x);
        var nright = self.GetNavRightPosition();
        $('.btn-continuum-float-right').css('top', nright.y);
        $('.btn-continuum-float-right').css('right', nright.x);

        //Bind category text
        self.bindCategoryText();

        //Bind Content
        self.BindContent();
    }
    return this;
}